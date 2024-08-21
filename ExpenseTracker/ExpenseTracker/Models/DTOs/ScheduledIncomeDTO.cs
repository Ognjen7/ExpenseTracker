namespace ExpenseTracker.Models.DTOs
{
    public class ScheduledIncomeDTO
    {
        public int ScheduledIncomeId { get; set; }
        public string? ScheduledIncomeName { get; set; }
        public string? ScheduledIncomeDescription { get; set; }
        public double? ScheduledIncomeAmount { get; set; }
        public DateTime? ScheduledIncomeDate { get; set; }
        public string? ApplicationUserId { get; set; }
        public int IncomeGroupId { get; set; }
    }
}
