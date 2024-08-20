using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.Entities
{
    public class IncomeGroup
    {
        public int IncomeGroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string? IncomeGroupName { get; set; }
        [Required]
        [StringLength(200)]
        public string? IncomeGroupDescription { get; set; }

        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public ICollection<Income>? Incomes { get; set; }
    }
}
