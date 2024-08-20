using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<IncomeGroup>? IncomeGroups { get; set; }
        public ICollection<ExpenseGroup>? ExpenseGroups { get; set; }
    }
}
