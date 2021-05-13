
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

        public async Task<AddressModel> MapAddress(int id)
        {
            Address addressModel = await GetEntityAsync(id);
            AddressModel mappedModel = _mapper.Map<AddressModel>(addressModel);
            return mappedModel;
        }

       
    }
}
