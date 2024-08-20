using ExpenseTracker.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<IncomeGroup> IncomeGroups { get; set; }
    public DbSet<ExpenseGroup> ExpenseGroups { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
