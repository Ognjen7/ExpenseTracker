namespace ExpenseTracker.Models.DTOs;

public class ExpenseDTO
{
    public int ExpenseId { get; set; }
    public string? ExpenseName { get; set; }
    public string? ExpenseDescription { get; set; }
    public double? ExpenseAmount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? ApplicationUserId { get; set; }
    public int ExpenseGroupId { get; set; }
}
