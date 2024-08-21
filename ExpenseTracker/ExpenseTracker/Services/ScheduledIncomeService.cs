using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;
using Hangfire;
using System.Runtime.CompilerServices;

namespace ExpenseTracker.Services;

public class ScheduledIncomeService : BaseService<ScheduledIncome, ScheduledIncomeDTO>, IScheduledIncomeService
{
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly IIncomeRepository _incomeRepository;
    private readonly IScheduledIncomeRepository _scheduledIncomeRepository;

    public ScheduledIncomeService(IScheduledIncomeRepository repository, IMapper mapper, IRecurringJobManager recurringJobManager, IIncomeRepository incomeRepository) : base(repository, mapper)
    {
        _scheduledIncomeRepository = repository;
        _recurringJobManager = recurringJobManager;
        _incomeRepository = incomeRepository;
    }

    public async Task ScheduleIncomeAsync(ScheduledIncome scheduledIncome)
    {
        // Save the scheduled income using the base repository method
        await _repository.AddAsync(scheduledIncome);

        // Schedule the job to trigger at the specified date
        string jobId = $"scheduledIncome-{scheduledIncome.ScheduledIncomeId}";

        if (scheduledIncome.IsRecurring)
        {
            _recurringJobManager.AddOrUpdate(
                jobId,
                () => ProcessScheduledIncomeAsync(scheduledIncome.ScheduledIncomeId),
                Cron.Monthly(scheduledIncome.ScheduledIncomeDate.Value.Day,
                             scheduledIncome.ScheduledIncomeDate.Value.Hour,
                             scheduledIncome.ScheduledIncomeDate.Value.Minute)
            );
        }
        else
        {
            BackgroundJob.Schedule(
                () => ProcessScheduledIncomeAsync(scheduledIncome.ScheduledIncomeId),
                scheduledIncome.ScheduledIncomeDate.Value
            );
        }
    }

    public async Task ProcessScheduledIncomeAsync(int scheduledIncomeId)
    {
        var scheduledIncome = await _scheduledIncomeRepository.GetByIdAsync(scheduledIncomeId);
        if (scheduledIncome != null)
        {
            var income = new Income
            {
                IncomeName = scheduledIncome.ScheduledIncomeName,
                IncomeDescription = scheduledIncome.ScheduledIncomeDescription,
                IncomeAmount = scheduledIncome.ScheduledIncomeAmount,
                IncomeDate = DateTime.Now,
                ApplicationUserId = scheduledIncome.ApplicationUserId,
                IncomeGroupId = scheduledIncome.IncomeGroupId
            };

            await _incomeRepository.AddAsync(income);

            if (scheduledIncome.IsRecurring)
            {
                // Reschedule the next occurrence
                scheduledIncome.ScheduledIncomeDate = scheduledIncome.ScheduledIncomeDate.Value.AddMonths(1);
                await _scheduledIncomeRepository.UpdateAsync(scheduledIncome);
            }
            else
            {
                // Remove from ScheduledIncomes if it's not recurring
                await _scheduledIncomeRepository.DeleteAsync(scheduledIncomeId);
            }
        }
    }
}
