using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Resource, ResourceModel>().ReverseMap();
        }
    }
}