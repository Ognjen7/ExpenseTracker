namespace ExpenseTracker.Models.DTOs;

public class IncomeDTO
{
    public int IncomeId { get; set; }
    public string? IncomeName { get; set; }
    public string? IncomeDescription { get; set; }
    public double? IncomeAmount { get; set; }
    public DateTime IncomeDate { get; set; }
    public string? ApplicationUserId { get; set; }
    public int IncomeGroupId { get; set; }

}
