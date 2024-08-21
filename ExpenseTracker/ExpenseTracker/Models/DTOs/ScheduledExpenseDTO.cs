namespace ExpenseTracker.Models.DTOs
{
    public class ScheduledExpenseDTO
    {
        public int ScheduledExpenseId { get; set; }
        public string? ScheduledExpenseName { get; set; }
        public string? ScheduledExpenseDescription { get; set; }
        public double? ScheduledExpenseAmount { get; set; }
        public DateTime? ScheduledExpenseDate { get; set; }
        public string? ApplicationUserId { get; set; }
        public int ExpenseGroupId { get; set; }
    }
}
