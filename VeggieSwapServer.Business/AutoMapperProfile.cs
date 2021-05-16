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
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Resource, ResourceModel>().ReverseMap();
            CreateMap<Purchase, PurchaseModel>().ReverseMap();
            CreateMap<Trade, TradeModel>().ReverseMap();
            CreateMap<TradeItem, TradeItemDTO>().ForMember(dest => dest.AcceptedResources, opt => opt.MapFrom(src => src.User.AcceptedResources))
                                                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));

            CreateMap<Wallet, WalletModel>().ReverseMap();
        }
    }
}