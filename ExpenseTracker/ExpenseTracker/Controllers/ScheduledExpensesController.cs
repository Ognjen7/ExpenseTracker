using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledExpensesController : ControllerBase
    {
        private readonly IScheduledExpenseService _scheduledExpenseService;

        public ScheduledExpensesController(IScheduledExpenseService service)
        {
            _scheduledExpenseService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledExpenseDTO>>> GetAll()
        {
            var scheduledExpense = await _scheduledExpenseService.GetAllAsync();
            return Ok(scheduledExpense);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledExpenseDTO>> GetById(int id)
        {
            var scheduledExpense = await _scheduledExpenseService.GetByIdAsync(id);
            if (scheduledExpense == null)
            {
                return NotFound();
            }
            return Ok(scheduledExpense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScheduledExpenseAsync(ScheduledExpenseDTO scheduledExpenseDto)
        {
            var scheduledExpense = new ScheduledExpense
            {
                ScheduledExpenseName = scheduledExpenseDto.ScheduledExpenseName,
                ScheduledExpenseDescription = scheduledExpenseDto.ScheduledExpenseDescription,
                ScheduledExpenseAmount = scheduledExpenseDto.ScheduledExpenseAmount,
                ScheduledExpenseDate = scheduledExpenseDto.ScheduledExpenseDate,
                ApplicationUserId = scheduledExpenseDto.ApplicationUserId,
                ExpenseGroupId = scheduledExpenseDto.ExpenseGroupId,
                IsRecurring = scheduledExpenseDto.IsRecurring
            };

            await _scheduledExpenseService.ScheduledExpenseAsync(scheduledExpense);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _scheduledExpenseService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ScheduledExpenseDTO scheduledExpenseDTO)
        {
            if (id != scheduledExpenseDTO.ScheduledExpenseId)
            {
                return BadRequest();
            }

            await _scheduledExpenseService.UpdateAsync(scheduledExpenseDTO);
            return NoContent();
        }
    }
}
