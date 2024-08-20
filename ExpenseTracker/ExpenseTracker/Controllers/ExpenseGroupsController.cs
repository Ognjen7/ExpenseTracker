using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseGroupsController : ControllerBase
    {

        private readonly IExpenseGroupService _expenseGroupService;


        public ExpenseGroupsController(IExpenseGroupService service)
        {
            _expenseGroupService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseGroupDTO>>> GetAll()
        {
            var expenseGroups = await _expenseGroupService.GetAllAsync();
            return Ok(expenseGroups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseGroupDTO>> GetById(int id)
        {
            var expenseGroup = await _expenseGroupService.GetByIdAsync(id);
            if (expenseGroup == null)
            {
                return NotFound();
            }
            return Ok(expenseGroup);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ExpenseGroupDTO expenseGroupDto)
        {
            await _expenseGroupService.AddAsync(expenseGroupDto);
            return CreatedAtAction(nameof(GetById), new { id = expenseGroupDto.ExpenseGroupId }, expenseGroupDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _expenseGroupService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ExpenseGroupDTO expenseGroupDto)
        {
            if (id != expenseGroupDto.ExpenseGroupId)
            {
                return BadRequest();
            }

            await _expenseGroupService.UpdateAsync(expenseGroupDto);
            return NoContent();
        }
    }
}
