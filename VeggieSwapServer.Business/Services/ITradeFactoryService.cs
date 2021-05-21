﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;

namespace VeggieSwapServer.Business.Services
{
    public interface ITradeFactoryService
    {
        Task<bool> ControllerAcceptTradeAsync(int userId, int receiverId);

        Task<IEnumerable<TradeItemDto>> ControllerGetsList(int userId, int receiverId);

        Task<bool> ControllerPushListAsync(IEnumerable<TradeItemDto> tradeList);

        Task GetTradeAsync();

        Task GetTradeItemProposalsAsync();

        void GetUsersId();

        Task UpdateTradeItemProposals();

        Task UpdateTradeItems();
    }
}