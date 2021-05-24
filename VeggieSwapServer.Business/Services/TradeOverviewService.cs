using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
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

            return _mapper.Map<IEnumerable<TradeDto>>(_tradeList);
        }
    }
}