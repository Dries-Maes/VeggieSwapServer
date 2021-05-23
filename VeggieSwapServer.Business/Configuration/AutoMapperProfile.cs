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
            CreateMap<TradeItem, TradeItemDto>()
                .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.Resource.Id))
                .ForMember(d => d.ResourceName, x => x.MapFrom(y => y.Resource.Name))
                .ForMember(d => d.ResourceImageUrl, x => x.MapFrom(y => y.Resource.ImageUrl))
                .ForMember(d => d.UserPostalCode, x => x.MapFrom(y => y.User.Address.PostalCode));
            CreateMap<TradeItemDto, TradeItem>()
                .ForMember(d => d.Id, x => x.MapFrom(y => y.Id))
                .ForMember(d => d.Amount, x => x.MapFrom(y => y.Amount))
                .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.ResourceId))
                .ForMember(d => d.UserId, x => x.MapFrom(y => y.UserId));
            CreateMap<User, UserDTO>()
                .ForMember(d => d.AddressID, x => x.MapFrom(y => y.Address.Id))
                .ForMember(d => d.AddressPostalCode, x => x.MapFrom(y => y.Address.PostalCode))
                .ForMember(d => d.AddressStreetName, x => x.MapFrom(y => y.Address.StreetName))
                .ForMember(d => d.AddressStreetNumber, x => x.MapFrom(y => y.Address.StreetNumber))
                .ForMember(d => d.WalletID, x => x.MapFrom(y => y.Wallet.Id));
            CreateMap<UserDTO, User>();
            CreateMap<Resource, ResourceDto>().ReverseMap();
        }
    }
}