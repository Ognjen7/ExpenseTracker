using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, ApplicationUserDTO>()
            .ForMember(dest => dest.ApplicationUserUserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.ApplicationUserEmail, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IncomeGroups, opt => opt.MapFrom(src => src.IncomeGroups))
            .ForMember(dest => dest.ExpenseGroups, opt => opt.MapFrom(src => src.ExpenseGroups))
            .ForMember(dest => dest.Incomes, opt => opt.MapFrom(src => src.Incomes))
            .ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses));
        CreateMap<IncomeGroup, IncomeGroupDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
        CreateMap<ExpenseGroup, ExpenseGroupDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
        CreateMap<Income, IncomeDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
        CreateMap<Expense, ExpenseDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
        CreateMap<ScheduledExpense, ScheduledExpenseDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
        CreateMap<ScheduledIncome, ScheduledIncomeDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
    }
}
