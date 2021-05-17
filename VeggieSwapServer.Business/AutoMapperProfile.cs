using AutoMapper;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<TradeItem, TradeItemDTO>()
                .ForMember(dest => dest.UserFirstName, a => a.MapFrom(s => s.User.FirstName))
                .ForMember(dest => dest.UserLastName, a => a.MapFrom(s => s.User.LastName));
        }
    }
}