using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.Entities
{
    public class ScheduledExpense
    {
        public int ScheduledExpenseId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please enter a name between 1 and 50 characters long")]
        public string? ScheduledExpenseName { get; set; }
        public string? ScheduledExpenseDescription { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Enter a value in range 1 - 1000000")]
        public double? ScheduledExpenseAmount { get; set; }

        [Required]
        public DateTime? ScheduledExpenseDate { get; set; }

        public bool IsRecurring { get; set; }

        public string? ApplicationUserId { get; set; }
        public int ExpenseGroupId { get; set; }
    }
}
