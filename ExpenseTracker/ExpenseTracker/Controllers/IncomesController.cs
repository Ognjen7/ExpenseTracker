using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Queries;
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
        private readonly IEmailService _emailService;
        private readonly IReportService _pdfReportService;

        public IncomesController(IIncomeService service, IEmailService emailService, IReportService pdfReportService)
        {
            _incomeService = service;
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

            var incomes = await _incomeService.GetAllAsync();
            var pdfReport = _pdfReportService.GenerateIncomePdfReport(incomes);

            await _emailService.SendEmailAsync(userEmail, "Your Income Report", "Please find attached your income report.", pdfReport, "IncomeReport.pdf");

            return Ok("Email sent successfully.");
        }

        [HttpGet("generateReport")]
        public async Task<IActionResult> GenerateReport(string userId)
        {
            var incomes = await _incomeService.GetByUserIdAsync(userId);
            if (incomes == null)
            {
                return NotFound();
            }

            byte[] pdfBytes = _pdfReportService.GenerateIncomePdfReport(incomes);

            return File(pdfBytes, "application/pdf", "IncomeReport.pdf");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeDTO>>> Query([FromQuery] TransactionQuery query)
        {
            var result = await _incomeService.QueryAsync(query);
            return Ok(result);
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
