using AutoMapper;
using System;
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

            CreateMap<Tuple<TradeItem, User>, TradeItemDTO>()
                .ForMember(dest => dest.AcceptedResources, a => a.MapFrom(s => s.Item2.AcceptedResources))
                .ForMember(dest => dest.FirstName, a => a.MapFrom(s => s.Item2.FirstName))
                .ForMember(dest => dest.LastName, a => a.MapFrom(s => s.Item2.LastName))
                .ForMember(dest => dest.Id, a => a.MapFrom(s => s.Item1.Id))
                .ForMember(dest => dest.Amount, a => a.MapFrom(s => s.Item1.Amount))
                .ForMember(dest => dest.UserId, a => a.MapFrom(s => s.Item1.UserId))
                .ForMember(dest => dest.Resource, a => a.MapFrom(s => s.Item1.Resource));
        }
    }
}