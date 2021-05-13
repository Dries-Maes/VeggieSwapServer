using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class UserService : GenericService<User>
    {
        public UserService(IGenericRepo<User> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<UserModel> MapUser(int id)
        //{
        //    User UserModel = await GetEntityAsync(id);
        //    UserModel mappedModel = _mapper.Map<UserModel>(UserModel);
        //    return mappedModel;
        //}

        public override object Map(User entity)
        {
            var test = _mapper.Map<UserModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}