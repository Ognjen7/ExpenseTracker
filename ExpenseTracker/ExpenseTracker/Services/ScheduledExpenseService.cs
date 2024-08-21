using AutoMapper;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;
using Hangfire;

namespace ExpenseTracker.Services
{
    public class ScheduledExpenseService : BaseService<ScheduledExpense, ScheduledExpenseDTO>, IScheduledExpenseService
    {
        private readonly IScheduledExpenseRepository _scheduledExpenseRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IRecurringJobManager _recurringJobManager;

        public ScheduledExpenseService(IScheduledExpenseRepository repository, IMapper mapper, IRecurringJobManager recurringJobManager, IExpenseRepository expenseRepository) : base(repository, mapper)
        {
            _scheduledExpenseRepository = repository;
            _recurringJobManager = recurringJobManager;
            _expenseRepository = expenseRepository;
        }

        public async Task ScheduledExpenseAsync(ScheduledExpense scheduledExpense)
        {
            await _repository.AddAsync(scheduledExpense);

            string jobId = $"scheduledExpense-{scheduledExpense.ScheduledExpenseId}";

            if (scheduledExpense.IsRecurring)
            {
                _recurringJobManager.AddOrUpdate(
                    jobId,
                    () => ProcessScheduledExpenseAsync(scheduledExpense.ScheduledExpenseId),
                    Cron.Monthly(scheduledExpense.ScheduledExpenseDate.Value.Day,
                                 scheduledExpense.ScheduledExpenseDate.Value.Hour,
                                 scheduledExpense.ScheduledExpenseDate.Value.Minute)
                );
            }
            else
            {
                BackgroundJob.Schedule(
                    () => ProcessScheduledExpenseAsync(scheduledExpense.ScheduledExpenseId),
                    scheduledExpense.ScheduledExpenseDate.Value
                );
            }
        }

        public async Task ProcessScheduledExpenseAsync(int scheduledExpenseId)
        {
            var scheduledExpense = await _scheduledExpenseRepository.GetByIdAsync(scheduledExpenseId);
            if (scheduledExpense != null)
            {
                var expense = new Expense
                {
                    ExpenseName = scheduledExpense.ScheduledExpenseName,
                    ExpenseDescription = scheduledExpense.ScheduledExpenseDescription,
                    ExpenseAmount = scheduledExpense.ScheduledExpenseAmount,
                    ExpenseDate = DateTime.Now,
                    ApplicationUserId = scheduledExpense.ApplicationUserId,
                    ExpenseGroupId = scheduledExpense.ExpenseGroupId
                };

                await _expenseRepository.AddAsync(expense);

                if (scheduledExpense.IsRecurring)
                {
                    // Reschedule the next occurrence
                    scheduledExpense.ScheduledExpenseDate = scheduledExpense.ScheduledExpenseDate.Value.AddMonths(1);
                    await _scheduledExpenseRepository.UpdateAsync(scheduledExpense);
                }
                else
                {
                    // Remove from ScheduledIncomes if it's not recurring
                    await _scheduledExpenseRepository.DeleteAsync(scheduledExpenseId);
                }
            }
        }

    }
}
