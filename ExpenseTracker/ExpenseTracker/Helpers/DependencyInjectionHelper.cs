using ExpenseTracker.Services.Interfaces;
using ExpenseTracker.Services;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Helpers;

public static class DependencyInjectionHelper
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationUserService, ApplicationUserService>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddScoped<IIncomeGroupRepository, IncomeGroupRepository>();
        services.AddScoped<IIncomeGroupService, IncomeGroupService>();
        services.AddScoped<IExpenseGroupRepository, ExpenseGroupRepository>();
        services.AddScoped<IExpenseGroupService, ExpenseGroupService>();
    }
}