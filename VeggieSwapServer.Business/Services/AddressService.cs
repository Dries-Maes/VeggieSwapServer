using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class AddressService : GenericService<Address>
    {
        public AddressService(IGenericRepo<Address> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<AddressModel> MapAddress(int id)
        //{
        //    Address addressModel = await GetEntityAsync(id);
        //    AddressModel mappedModel = _mapper.Map<AddressModel>(addressModel);
        //    return mappedModel;
        //}

        public override object Map(Address entity)
        {
            var test = _mapper.Map<AddressModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}