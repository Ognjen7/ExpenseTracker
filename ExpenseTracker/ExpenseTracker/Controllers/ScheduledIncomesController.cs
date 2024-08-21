using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    [Route("api/scheduled-income")]
    [ApiController]
    public class ScheduledIncomesController : ControllerBase
    {
        private readonly IScheduledIncomeService _scheduledIncomeService;

        public ScheduledIncomesController(IScheduledIncomeService service)
        {
            _scheduledIncomeService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledIncomeDTO>>> GetAll()
        {
            var scheduledIncome = await _scheduledIncomeService.GetAllAsync();
            return Ok(scheduledIncome);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledIncomeDTO>> GetById(int id)
        {
            var scheduledIncome = await _scheduledIncomeService.GetByIdAsync(id);
            if (scheduledIncome == null)
            {
                return NotFound();
            }
            return Ok(scheduledIncome);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScheduledIncomeAsync(ScheduledIncomeDTO scheduledIncomeDto)
        {
            var scheduledIncome = new ScheduledIncome
            {
                ScheduledIncomeName = scheduledIncomeDto.ScheduledIncomeName,
                ScheduledIncomeDescription = scheduledIncomeDto.ScheduledIncomeDescription,
                ScheduledIncomeAmount = scheduledIncomeDto.ScheduledIncomeAmount,
                ScheduledIncomeDate = scheduledIncomeDto.ScheduledIncomeDate,
                ApplicationUserId = scheduledIncomeDto.ApplicationUserId,
                IncomeGroupId = scheduledIncomeDto.IncomeGroupId,
                IsRecurring = scheduledIncomeDto.IsRecurring
            };

            await _scheduledIncomeService.ScheduleIncomeAsync(scheduledIncome);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _scheduledIncomeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ScheduledIncomeDTO scheduledIncomeDTO)
        {
            if (id != scheduledIncomeDTO.ScheduledIncomeId)
            {
                return BadRequest();
            }

            await _scheduledIncomeService.UpdateAsync(scheduledIncomeDTO);
            return NoContent();
        }
    }
}
