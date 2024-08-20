namespace ExpenseTracker.Models.DTOs
{
    public class ApplicationUserDTO
    {
        public string? ApplicationUserId { get; set; }
        public string? ApplicationUserUserName { get; set; }
        public string? ApplicationUserEmail { get; set; }
        public ICollection<IncomeGroupDTO>? IncomeGroups { get; set; }
        public ICollection<ExpenseGroupDTO>? ExpenseGroups { get; set; }
    }
}
