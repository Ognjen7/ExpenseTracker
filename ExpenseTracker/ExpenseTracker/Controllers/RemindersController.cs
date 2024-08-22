using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/reminders")]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        private readonly IExpenseService _expenseService;
        private readonly IIncomeService _incomeService;

        public RemindersController(
            IReminderService reminderService,
            IExpenseService expenseService,
            IIncomeService incomeService)
        {
            _reminderService = reminderService;
            _expenseService = expenseService;
            _incomeService = incomeService;
        }

        [HttpPost("weeklyReminder")]
        [Authorize(Policy = "PremiumOnly")]
        public async Task<IActionResult> AddAndScheduleWeeklyReminder([FromBody] WeeklyReminderDTO weeklyReminderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _reminderService.ScheduleWeeklyReminderAsync(weeklyReminderDTO);
            return Ok("Weekly reminder added and scheduled successfully.");
        }

        [HttpPost("monthlyReminder")]
        [Authorize(Policy = "PremiumOnly")]
        public async Task<IActionResult> AddAndScheduleMonthlyReminder([FromBody] MonthlyReminderDTO monthlyReminderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _reminderService.ScheduleMonthlyReminderAsync(monthlyReminderDTO);
            return Ok("Monthly reminder added and scheduled successfully.");
        }

        [HttpGet("getAllReminders")]
        public async Task<IActionResult> GetAllReminders()
        {
            var reminders = await _reminderService.GetAllRemindersAsync();
            return Ok(reminders);
        }

        [HttpGet("getExpensesForLastWeek/{userId}")]
        public async Task<IActionResult> GetExpensesForLastWeek(string userId)
        {
            var expenses = await _expenseService.GetExpensesForLastWeek(userId);
            return Ok(expenses);
        }

        [HttpGet("getIncomesForLastWeek/{userId}")]
        public async Task<IActionResult> GetIncomesForLastWeek(string userId)
        {
            var incomes = await _incomeService.GetIncomesForLastWeek(userId);
            return Ok(incomes);
        }

        [HttpGet("getExpensesForLastMonth/{userId}")]
        public async Task<IActionResult> GetExpensesForLastMonth(string userId)
        {
            var expenses = await _expenseService.GetExpensesForLastMonth(userId);
            return Ok(expenses);
        }

        [HttpGet("getIncomesForLastMonth/{userId}")]
        public async Task<IActionResult> GetIncomesForLastMonth(string userId)
        {
            var incomes = await _incomeService.GetIncomesForLastMonth(userId);
            return Ok(incomes);
        }
    }
}
