using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class ResourceService : GenericService<Resource>
    {
        public ResourceService(IGenericRepo<Resource> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<ResourceModel> MapResource(int id)
        //{
        //    Resource ResourceModel = await GetEntityAsync(id);
        //    ResourceModel mappedModel = _mapper.Map<ResourceModel>(ResourceModel);
        //    return mappedModel;
        //}

        public override object Map(Resource entity)
        {
            var test = _mapper.Map<ResourceModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}