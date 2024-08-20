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
            .ForMember(dest => dest.ExpenseGroups, opt => opt.MapFrom(src => src.ExpenseGroups));
        CreateMap<IncomeGroup, IncomeGroupDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
        CreateMap<ExpenseGroup, ExpenseGroupDTO>()
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            .ReverseMap();
    }
}
