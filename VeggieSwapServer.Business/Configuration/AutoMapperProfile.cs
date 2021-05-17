using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TradeItem, TradeItemDto>();
            CreateMap<User, UserDTO>()
                .ForMember(d => d.AddressID, x => x.MapFrom(y => y.Address.Id))
                .ForMember(d => d.AddressPostalCode, x => x.MapFrom(y => y.Address.PostalCode))
                .ForMember(d => d.AddressStreetName, x => x.MapFrom(y => y.Address.StreetName))
                .ForMember(d => d.WalletID, x => x.MapFrom(y => y.Wallet.Id));
            CreateMap<Resource, ResourceDto>().ReverseMap();
        }
    }
}