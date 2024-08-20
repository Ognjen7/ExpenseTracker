using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    [Route("api/income")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService service)
        {
            _incomeService = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeDTO>> GetById(int id)
        {
            var income = await _incomeService.GetByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            return Ok(income);
        }

        [HttpPost]
        public async Task<ActionResult> Add(IncomeDTO incomeDTO)
        {
            await _incomeService.AddAsync(incomeDTO);
            return CreatedAtAction(nameof(GetById), new { id = incomeDTO.IncomeId }, incomeDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _incomeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, IncomeDTO incomeDTO)
        {
            if (id != incomeDTO.IncomeId)
            {
                return BadRequest();
            }

            await _incomeService.UpdateAsync(incomeDTO);
            return NoContent();
        }
    }
}
