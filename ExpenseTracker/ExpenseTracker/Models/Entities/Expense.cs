using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.Entities;

public class Expense
{
    public int ExpenseId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Please enter a valid name")]
    public string? ExpenseName { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Please enter a valid description")]
    public string? ExpenseDescription { get; set; }

    [Required]
    [Range(1, 1000000, ErrorMessage = "Please enter a valid value")]
    public double? ExpenseAmount { get; set; }

    [Required]
    public DateTime ExpenseDate { get; set; }

    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }

    public int ExpenseGroupId { get; set; }
    public ExpenseGroup? ExpenseGroup { get; set; }
}
