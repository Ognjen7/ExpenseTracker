using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ExpenseTracker.Services;

public class ReminderService : IReminderService
{
    private readonly IApplicationUserService _userService;
    private readonly IEmailService _emailService;
    private readonly IReportService _reportService;
    private readonly IReminderRepository _reminderRepository;
    private readonly IExpenseService _expenseService;
    private readonly IIncomeService _incomeService;
    private readonly ILogger<ReminderService> _logger;

    public ReminderService(IEmailService emailService, IReportService reportService,
        IReminderRepository reminderRepository, IExpenseService expenseService,
        IIncomeService incomeService, ILogger<ReminderService> logger, IApplicationUserService userService)
    {
        _emailService = emailService;
        _reportService = reportService;
        _reminderRepository = reminderRepository;
        _expenseService = expenseService;
        _incomeService = incomeService;
        _logger = logger;
        _userService = userService;
    }

    public async Task ScheduleWeeklyReminderAsync(WeeklyReminderDTO weeklyReminderDto)
    {
        var reminder = new Reminder
        {
            ApplicationUserId = weeklyReminderDto.ApplicationUserId,
            Hour = weeklyReminderDto.Hour,
            Minute = weeklyReminderDto.Minute,
            DayOfWeek = weeklyReminderDto.DayOfWeek,
            ReminderType = ReminderType.Weekly,
            ScheduledTime = DateTime.UtcNow
        };

        await _reminderRepository.AddAsync(reminder);

        ScheduleWeeklyReminder(reminder);
    }

    public async Task ScheduleMonthlyReminderAsync(MonthlyReminderDTO monthlyReminderDto)
    {
        var reminder = new Reminder
        {
            ApplicationUserId = monthlyReminderDto.ApplicationUserId,
            Hour = monthlyReminderDto.Hour,
            Minute = monthlyReminderDto.Minute,
            DayOfMonth = monthlyReminderDto.DayOfMonth,
            ReminderType = ReminderType.Monthly,
            ScheduledTime = DateTime.UtcNow
        };

        await _reminderRepository.AddAsync(reminder);

        ScheduleMonthlyReminder(reminder);
    }

    private void ScheduleWeeklyReminder(Reminder reminder)
    {
        RecurringJob.AddOrUpdate(
            reminder.ReminderId.ToString(),
            () => SendWeeklyReminder(reminder.ReminderId),
            Cron.Weekly((DayOfWeek)reminder.DayOfWeek!, reminder.Hour, reminder.Minute)
        );
    }

    private void ScheduleMonthlyReminder(Reminder reminder)
    {
        RecurringJob.AddOrUpdate(
            reminder.ReminderId.ToString(),
            () => SendMonthlyReminder(reminder.ReminderId),
            Cron.Monthly((int)reminder.DayOfMonth!, reminder.Hour, reminder.Minute)
        );
    }

    public async Task SendWeeklyReminder(int reminderId)
    {
        var reminder = await _reminderRepository.GetByIdAsync(reminderId);
        if (reminder == null || reminder.ReminderType != ReminderType.Weekly)
        {
            _logger.LogError($"Reminder with ID {reminderId} not found or is not a weekly reminder.");
            return;
        }

        var user = await _userService.GetUserByIdAsync(reminder.ApplicationUserId);
        if (user == null || string.IsNullOrEmpty(user.ApplicationUserEmail))
        {
            _logger.LogError($"User with ID {reminder.ApplicationUserId} not found or email is missing.");
            return;
        }

        try
        {
            var expenses = await _expenseService.GetExpensesForLastWeek(reminder.ApplicationUserId);
            var incomes = await _incomeService.GetIncomesForLastWeek(reminder.ApplicationUserId);

            byte[] expenseReport = _reportService.GenerateExpensePdfReport(expenses);
            byte[] incomeReport = _reportService.GenerateIncomePdfReport(incomes);

            await _emailService.SendEmailAsync(
                user.ApplicationUserEmail,
                "Weekly Expense and Income Report",
                "Here is your weekly report.",
                expenseReport.Length > 0 ? expenseReport : null,
                "WeeklyExpenseReport.pdf"
            );

            await _emailService.SendEmailAsync(
                user.ApplicationUserEmail,
                "Weekly Expense and Income Report",
                "Here is your weekly report.",
                incomeReport.Length > 0 ? incomeReport : null,
                "WeeklyIncomeReport.pdf"
            );
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending weekly reminder for user {reminder.ApplicationUserId}: {ex.Message}");
        }
    }

    public async Task SendMonthlyReminder(int reminderId)
    {
        var reminder = await _reminderRepository.GetByIdAsync(reminderId);
        if (reminder == null || reminder.ReminderType != ReminderType.Monthly)
        {
            _logger.LogError($"Reminder with ID {reminderId} not found or is not a monthly reminder.");
            return;
        }

        var user = await _userService.GetUserByIdAsync(reminder.ApplicationUserId);
        if (user == null || string.IsNullOrEmpty(user.ApplicationUserEmail))
        {
            _logger.LogError($"User with ID {reminder.ApplicationUserId} not found or email is missing.");
            return;
        }

        try
        {
            var expenses = await _expenseService.GetExpensesForLastMonth(reminder.ApplicationUserId);
            var incomes = await _incomeService.GetIncomesForLastMonth(reminder.ApplicationUserId);

            byte[] expenseReport = _reportService.GenerateExpensePdfReport(expenses);
            byte[] incomeReport = _reportService.GenerateIncomePdfReport(incomes);

            await _emailService.SendEmailAsync(
                user.ApplicationUserEmail,
                "Monthly Expense and Income Report",
                "Here is your monthly report.",
                expenseReport.Length > 0 ? expenseReport : null,
                "MonthlyExpenseReport.pdf"
            );

            await _emailService.SendEmailAsync(
                user.ApplicationUserEmail,
                "Monthly Expense and Income Report",
                "Here is your monthly report.",
                incomeReport.Length > 0 ? incomeReport : null,
                "MonthlyIncomeReport.pdf"
            );
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending monthly reminder for user {reminder.ApplicationUserId}: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Reminder>> GetRemindersByUserIdAsync(string userId)
    {
        return await _reminderRepository.GetRemindersByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Reminder>> GetAllRemindersAsync()
    {
        return await _reminderRepository.GetAllAsync();
    }
}
