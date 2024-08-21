using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Queries;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers;

[Authorize]
[Route("api/expenses")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService service)
    {
        _expenseService = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> Query([FromQuery] TransactionQuery query)
    {
        var result = await _expenseService.QueryAsync(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseDTO>> GetById(int id)
    {
        var expense = await _expenseService.GetByIdAsync(id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult> Add(ExpenseDTO expenseDTO)
    {
        await _expenseService.AddAsync(expenseDTO);
        return CreatedAtAction(nameof(GetById), new { id = expenseDTO.ExpenseId }, expenseDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _expenseService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ExpenseDTO expenseDTO)
    {
        if (id != expenseDTO.ExpenseId)
        {
            return BadRequest();
        }

        await _expenseService.UpdateAsync(expenseDTO);
        return NoContent();
    }
}
