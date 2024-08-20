using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.Entities;

public class Income
{
    public int IncomeId { get; set; }

    [Required]
    [StringLength(20)]
    public string? IncomeName { get; set; }

    [Required]
    [StringLength(150)]
    public string? IncomeDescription { get; set; }

    [Required]
    [Range(1, 10000000, ErrorMessage = "Please enter a valid value")]
    public double? IncomeAmount { get; set; }

    [Required]
    public DateTime? IncomeDate { get; set; }

    public int IncomeGroupId { get; set; }
    public IncomeGroup IncomeGroup { get; set; }

    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
