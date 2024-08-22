using ExpenseTracker.Models.DTOs;

namespace ExpenseTracker.Services.Interfaces;

public interface IReportService
{
    byte[] GenerateIncomePdfReport(IEnumerable<IncomeDTO> incomes);
    byte[] GenerateExpensePdfReport(IEnumerable<ExpenseDTO> expenses);
}
