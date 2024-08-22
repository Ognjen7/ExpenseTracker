﻿using ExpenseTracker.Services.Interfaces;
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
        services.AddScoped<IIncomeRepository, IncomeRepository>();
        services.AddScoped<IIncomeService, IncomeService>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IScheduledIncomeRepository, ScheduledIncomeRepository>();
        services.AddScoped<IScheduledIncomeService, ScheduledIncomeService>();
        services.AddScoped<IScheduledExpenseRepository, ScheduledExpenseRepository>();
        services.AddScoped<IScheduledExpenseService, ScheduledExpenseService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IReminderRepository, ReminderRepository>();
        services.AddScoped<IReminderService, ReminderService>();

    }
}