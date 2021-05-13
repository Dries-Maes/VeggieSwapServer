using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}
