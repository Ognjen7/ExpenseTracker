using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.Entities
{
    public class ExpenseGroup
    {
        public int ExpenseGroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string? ExpenseGroupName { get; set; }
        [Required]
        [StringLength(200)]
        public string? ExpenseGroupDescription { get; set; }
        public double? ExpenseGroupBudgetCap { get; set; }

        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
