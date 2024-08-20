namespace ExpenseTracker.Models.DTOs;

public class ExpenseGroupDTO
{
    public int ExpenseGroupId { get; set; }
    public string? ExpenseGroupName { get; set; }
    public string? ExpenseGroupDescription { get; set; }
    public int? ExpenseGroupBudgetCap { get; set; }
    public string? ApplicationUserId { get; set; }
}
