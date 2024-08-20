using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/income-groups")]
    [ApiController]
    public class IncomeGroupsController : ControllerBase
    {
        private readonly IIncomeGroupService _incomeGroupService;


        public IncomeGroupsController(IIncomeGroupService service)
        {
            _incomeGroupService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeGroupDTO>>> GetAll()
        {
            var incomeGroups = await _incomeGroupService.GetAllAsync();
            return Ok(incomeGroups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeGroupDTO>> GetById(int id)
        {
            var incomeGroup = await _incomeGroupService.GetByIdAsync(id);
            if (incomeGroup == null)
            {
                return NotFound();
            }
            return Ok(incomeGroup);
        }

        [HttpPost]
        public async Task<ActionResult> Add(IncomeGroupDTO incomeGroupDto)
        {
            await _incomeGroupService.AddAsync(incomeGroupDto);
            return CreatedAtAction(nameof(GetById), new { id = incomeGroupDto.IncomeGroupId }, incomeGroupDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _incomeGroupService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, IncomeGroupDTO incomeGroupDto)
        {
            if (id != incomeGroupDto.IncomeGroupId)
            {
                return BadRequest();
            }

            await _incomeGroupService.UpdateAsync(incomeGroupDto);
            return NoContent();
        }
    }
}
