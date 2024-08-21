using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Models.DTOs
{
    public class ApplicationUserDTO
    {
        public string? ApplicationUserId { get; set; }
        public string? ApplicationUserUserName { get; set; }
        public string? ApplicationUserEmail { get; set; }
        public ICollection<IncomeGroupDTO>? IncomeGroups { get; set; }
        public ICollection<ExpenseGroupDTO>? ExpenseGroups { get; set; }
        public ICollection<IncomeDTO>? Incomes { get; set; }
        public ICollection<ExpenseDTO>? Expenses { get; set; }
        public ICollection<ScheduledIncome>? ScheduledIncomes { get; set; }
        public ICollection<ScheduledExpense>? ScheduledExpenses { get; set; }
    }
}
