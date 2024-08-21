using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.Entities
{
    public class ScheduledIncome
    {
        public int ScheduledIncomeId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please enter a name between 1 and 50 characters long")]
        public string? ScheduledIncomeName { get; set; }
        public string? ScheduledIncomeDescription { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Enter a value in range 1 - 1000000")]
        public double? ScheduledIncomeAmount { get; set; }

        [Required]
        public DateTime? ScheduledIncomeDate { get; set; }

        public bool IsRecurring { get; set; }

        public string? ApplicationUserId { get; set; }
        public int IncomeGroupId { get; set; }
    }
}
