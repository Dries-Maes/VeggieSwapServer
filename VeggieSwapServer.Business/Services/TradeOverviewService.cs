using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeOverviewService : ITradeOverviewService
    {
        private IEnumerable<Trade> _tradeList;
        private TradeRepo _tradeRepo;
        private IMapper _mapper;

        public TradeOverviewService(TradeRepo tradeRepo, IMapper mapper)
        {
            _tradeRepo = tradeRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TradeDto>> ControllerGetsList(int userId)
        {
            _tradeList = await _tradeRepo.GetTradeListFromUserAsync(userId);
            var mappedTrade = _mapper.Map<IEnumerable<TradeDto>>(_tradeList);
            foreach (var item in mappedTrade)
            {
                var proposer = _tradeList.FirstOrDefault(x => x.Id == item.Id).Proposer;
                if (proposer.Id == userId)
                {
                    item.User = _mapper.Map<UserDto>(_tradeList.FirstOrDefault(x => x.Id == item.Id).Receiver);
                }
                else
                {
                    item.User = _mapper.Map<UserDto>(proposer);
                }
            }

            return mappedTrade;
        }
    }
}