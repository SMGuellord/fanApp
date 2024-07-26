using AutoMapper;
using FanApp.Common.Models;
using FanApp.Common.Models.Dtos;

namespace FanApp.Common.Mappings
{
    public class FanAppMappings : Profile
    {
        public FanAppMappings() 
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Firstname,
                    opt => opt.MapFrom(src => src.Fistname))
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.Lastname))
                .ReverseMap();
        }
    }
}
