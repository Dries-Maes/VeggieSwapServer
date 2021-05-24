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
            CreateMap<TradeItemProposal, TradeItemDto>()
                .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.TradeItem.Resource.Id))
                .ForMember(d => d.ResourceName, x => x.MapFrom(y => y.TradeItem.Resource.Name))
                .ForMember(d => d.ResourceImageUrl, x => x.MapFrom(y => y.TradeItem.Resource.ImageUrl))
                .ForMember(d => d.UserId, x => x.MapFrom(y => y.TradeItem.UserId));
            CreateMap<TradeItemDto, TradeItem>()
                .ForMember(d => d.Id, x => x.MapFrom(y => y.Id))
                .ForMember(d => d.Amount, x => x.MapFrom(y => y.Amount))
                .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.ResourceId))
                .ForMember(d => d.UserId, x => x.MapFrom(y => y.UserId));

            CreateMap<User, UserDto>()
                .ForMember(d => d.AddressID, x => x.MapFrom(y => y.Address.Id))
                .ForMember(d => d.AddressPostalCode, x => x.MapFrom(y => y.Address.PostalCode))
                .ForMember(d => d.AddressStreetName, x => x.MapFrom(y => y.Address.StreetName))
                .ForMember(d => d.AddressStreetNumber, x => x.MapFrom(y => y.Address.StreetNumber))
                .ForMember(d => d.WalletID, x => x.MapFrom(y => y.Wallet.Id));
            CreateMap<UserDto, User>();
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<Trade, TradeDto>()
                .ForMember(d => d.Id, x => x.MapFrom(y => y.Id))
                .ForMember(d => d.CreatedAt, x => x.MapFrom(y => y.CreatedAt))
                .ForMember(d => d.ModifiedAt, x => x.MapFrom(y => y.ModifiedAt))
                .ForMember(d => d.Completed, x => x.MapFrom(y => y.Completed))
                .ForMember(d => d.ActiveUserId, x => x.MapFrom(y => y.ActiveUserId))
                .ForMember(d => d.TradeItemProposals, x => x.MapFrom(y => y.TradeItemProposals))
                .ForMember(d => d.Proposer, x => x.MapFrom(y => y.Proposer))
                .ForMember(d => d.Receiver, x => x.MapFrom(y => y.Receiver));
        }
    }
}