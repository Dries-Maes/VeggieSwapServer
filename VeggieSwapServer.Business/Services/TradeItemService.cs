﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeItemService : GenericService<TradeItem, TradeItemDTO>
    {
        private UserRepo _userRepo;

        public TradeItemService(IGenericRepo<TradeItem> genericRepo, IMapper mapper, UserRepo userRepo)
            : base(genericRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async override Task<IEnumerable<TradeItemDTO>> GetAllEntitiesAsync()
        {
            IEnumerable<TradeItem> tradeItems = await _genericRepo.GetAllEntitiesAsync();
            IEnumerable<User> Users = await _userRepo.GetAllEntitiesAsync();
            var result = new List<TradeItemDTO>();
            foreach (var tradeItem in tradeItems)
            {
                User user = Users.FirstOrDefault(x => x.Id == tradeItem.Id);
                var item = new TradeItemDTO
                {
                    AcceptedResources = user.AcceptedResources,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = tradeItem.Id,
                    Amount = tradeItem.Amount,
                    Resource = tradeItem.Resource,
                    UserId = tradeItem.UserId
                };
                result.Add(item);
            }
            return result;
        }
    }
}