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
            .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id));
    }
}
