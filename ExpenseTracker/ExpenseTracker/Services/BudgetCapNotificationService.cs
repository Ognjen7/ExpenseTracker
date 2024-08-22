using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;

namespace ExpenseTracker.Services
{
    public class BudgetCapNotificationService
    {
        private readonly IExpenseGroupRepository _expenseGroupRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IReportService _reportService;
        private readonly IEmailService _emailService;
        private readonly IApplicationUserService _userService;
        private readonly ILogger<BudgetCapNotificationService> _logger;
        private readonly IMapper _mapper;

        public BudgetCapNotificationService(
            IExpenseGroupRepository expenseGroupRepository,
            IExpenseRepository expenseRepository,
            IReportService reportService,
            IEmailService emailService,
            ILogger<BudgetCapNotificationService> logger,
            IMapper mapper,
            IApplicationUserService userService)
        {
            _expenseGroupRepository = expenseGroupRepository;
            _expenseRepository = expenseRepository;
            _reportService = reportService;
            _emailService = emailService;
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task CheckAndNotifyBudgetCapExceededAsync()
        {
            try
            {
                var expenseGroups = await _expenseGroupRepository.GetAllAsync();

                foreach (var group in expenseGroups)
                {
                    var totalExpenses = await _expenseRepository.GetTotalExpensesForGroupAsync(group.ExpenseGroupId);

                    if (totalExpenses > group.ExpenseGroupBudgetCap)
                    {
                        var groupDto = _mapper.Map<ExpenseGroupDTO>(group);

                        await NotifyBudgetCapExceededAsync(groupDto);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error checking budget caps: {ex.Message}");
            }
        }

        private async Task NotifyBudgetCapExceededAsync(ExpenseGroupDTO expenseGroup)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(expenseGroup.ApplicationUserId);
                var userEmail = user.ApplicationUserEmail;
                var pdfReport = await GenerateExpenseGroupReportAsync(expenseGroup.ExpenseGroupId);

                var emailSubject = $"Budget Cap Exceeded: {expenseGroup.ExpenseGroupName}";
                var emailBody = $"Your budget cap of {expenseGroup.ExpenseGroupBudgetCap:C} for the group '{expenseGroup.ExpenseGroupName}' has been exceeded. Keep track of your expenses!";

                await _emailService.SendEmailAsync(
                    userEmail,
                    emailSubject,
                    emailBody,
                    pdfReport,
                    "ExpenseGroupReport.pdf"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email notification for budget cap exceedance: {ex.Message}");
            }
        }

        private async Task<byte[]> GenerateExpenseGroupReportAsync(int expenseGroupId)
        {
            var expenses = await _expenseRepository.GetExpensesByGroupIdAsync(expenseGroupId);

            var expenseDTOs = _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);

            return _reportService.GenerateExpensePdfReport(expenseDTOs);
        }
    }
}
