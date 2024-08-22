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
    private readonly IEmailService _emailService;
    private readonly IReportService _pdfReportService;

    public ExpensesController(IExpenseService service, IEmailService emailService, IReportService pdfReportService)
    {
        _expenseService = service;
        _emailService = emailService;
        _pdfReportService = pdfReportService;
    }

    [HttpGet("email-report")]
    public async Task<IActionResult> SendIncomeReport()
    {
        var userEmail = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrEmpty(userEmail))
        {
            return BadRequest("User email not found.");
        }

        var expenses = await _expenseService.GetAllAsync();
        var pdfReport = _pdfReportService.GenerateExpensePdfReport(expenses);

        await _emailService.SendEmailAsync(userEmail, "Your Income Report", "Please find attached your income report.", pdfReport, "IncomeReport.pdf");

        return Ok("Email sent successfully.");
    }

    [HttpGet("generateReport")]
    public async Task<IActionResult> GenerateReport(string userId)
    {
        var expenses = await _expenseService.GetByUserIdAsync(userId);
        if (expenses == null)
        {
            return NotFound();
        }

        byte[] pdfBytes = _pdfReportService.GenerateExpensePdfReport(expenses);

        return File(pdfBytes, "application/pdf", "ExpenseReport.pdf");
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
