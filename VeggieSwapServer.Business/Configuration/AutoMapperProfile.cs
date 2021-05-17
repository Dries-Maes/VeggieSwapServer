using AutoMapper;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}