using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeFactoryService : ITradeFactoryService
    {
        private int _trader2Id;
        private int _trader1Id;
        private Trade _trade;
        private List<TradeItemProposal> _tradeItemProposals;
        private List<TradeItemDto> _tradeItemDTOList;
        private List<TradeItem> _tradeItemList;
        private ITradeItemService _tradeItemService;
        private IGenericRepo<TradeItemProposal> _tradeItemProposalRepo;
        private ITradeRepo _tradeRepo;
        private ITradeItemRepo _tradeItemRepo;

        public TradeFactoryService(ITradeRepo tradeRepo, ITradeItemService tradeItemService, IGenericRepo<TradeItemProposal> tradeItemProposalRepo, ITradeItemRepo tradeItemRepo)
        {
            _tradeItemRepo = tradeItemRepo;
            _tradeItemProposalRepo = tradeItemProposalRepo;
            _tradeItemDTOList = new List<TradeItemDto>();
            _tradeItemService = tradeItemService;
            _tradeRepo = tradeRepo;
            _tradeItemList = new List<TradeItem>();
        }

        public async Task<bool> ControllerPushListAsync(IEnumerable<TradeItemDto> tradeList)
        {
            _tradeItemDTOList = tradeList.ToList();
            GetUsersId();
            await GetTradeAsync();

            if (_trade == null)
            {
                CreateNewTrade();
                await _tradeRepo.AddEntityAsync(_trade);
                CreateTradeItemProposals();
                await UpdateTradeItemProposals();
            }
            else
            {
                await RemoveExistingTradeItemProposals();
                CreateTradeItemProposals();
                await UpdateTradeItemProposals();
                ToggleActiveUser();
                await _tradeRepo.UpdateEntityAsync(_trade);
            }
            return true;
        }

        public async Task<IEnumerable<TradeItemDto>> ControllerGetsListAsync(int userId, int receiverId)
        {
            _trader1Id = userId;
            _trader2Id = receiverId;
            await GetTradeAsync();

            await FetchTradeItemDtoList();

            if (_trade == null)
            {
                return _tradeItemDTOList.Where(x => x.Amount != 0 || x.ProposedAmount > 0);
            }
            else
            {
                await GetTradeItemProposalsAsync();
                SetProposedAmounts();
                SetActiveUserId();

                return _tradeItemDTOList.Where(x => x.Amount != 0 || x.ProposedAmount > 0);
            }
        }

        public async Task<bool> ControllerAcceptTradeAsync(int userId, int receiverId)
        {
            _trader1Id = userId;
            _trader2Id = receiverId;
            await GetTradeAsync();

            if (_trade != null)
            {
                await FetchTradeItemList();

                await GetTradeItemProposalsAsync();

                foreach (var proposal in _tradeItemProposals)
                {
                    try
                    {
                        _tradeItemList.FirstOrDefault(x => x.Id == proposal.TradeItemId).Amount -= proposal.ProposedAmount;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        throw new ArgumentOutOfRangeException("Insufficiant resources", e); // add 'e' as info
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

                await _tradeItemRepo.UpdateEntitiesAsync(_tradeItemList);
                _trade.Completed = true;
                await _tradeRepo.UpdateEntityAsync(_trade);
                return true;
            }

            return false;
        }

        public async Task<bool> ControllerCancelTradeAsync(int userId, int receiverId)
        {
            _trader1Id = userId;
            _trader2Id = receiverId;
            await GetTradeAsync();

            if (_trade != null)
            {
                await GetTradeItemProposalsAsync();
                await _tradeItemProposalRepo.DeleteEntitiesAsync(_tradeItemProposals);
                await _tradeRepo.DeleteEntityAsync(_trade.Id);

                return true;
            }

            return false;
        }

        private async Task FetchTradeItemList()
        {
            _tradeItemList.AddRange(await _tradeItemRepo.GetAllTradeItemsByUserIdAsync(_trader1Id));
            _tradeItemList.AddRange(await _tradeItemRepo.GetAllTradeItemsByUserIdAsync(_trader2Id));
        }

        private void SetProposedAmounts()
        {
            foreach (var proposal in _tradeItemProposals)
            {
                var item = _tradeItemDTOList.FirstOrDefault(x => x.Id == proposal.TradeItemId);

                if (item != null)
                {
                    item.ProposedAmount = proposal.ProposedAmount;
                }
            }
        }

        private void SetActiveUserId()
        {
            foreach (var item in _tradeItemDTOList)
            {
                item.ActiveUserId = _trade.ActiveUserId;
            }
        }

        private void ToggleActiveUser()
        {
            _trade.ActiveUserId = _trade.ActiveUserId == _trader1Id ? _trader2Id : _trader1Id;
        }

        private void CreateNewTrade()
        {
            _trade = new Trade
            {
                ActiveUserId = _tradeItemDTOList[0].ActiveUserId,
                ReceiverId = _tradeItemDTOList[0].ActiveUserId,
                ProposerId = _tradeItemDTOList[0].ActiveUserId == _trader1Id ? _trader2Id : _trader1Id,
            };
        }

        private async Task FetchTradeItemDtoList()
        {
            _tradeItemDTOList.AddRange(await _tradeItemService.GetTradeItemDetailListDtoAsync(_trader1Id));
            _tradeItemDTOList.AddRange(await _tradeItemService.GetTradeItemDetailListDtoAsync(_trader2Id));
        }

        private void GetUsersId()
        {
            _trader1Id = _tradeItemDTOList[0].UserId;
            _trader2Id = _tradeItemDTOList.FirstOrDefault(x => x.UserId != _trader1Id).UserId;
        }

        private async Task GetTradeAsync()
        {
            _trade = await _tradeRepo.GetTradeAsync(_trader1Id, _trader2Id);
        }

        private async Task GetTradeItemProposalsAsync()
        {
            var values = await _tradeItemProposalRepo.GetAllEntitiesAsync();
            _tradeItemProposals = values.Where(x => x.TradeId == _trade.Id).ToList();
        }

        private async Task UpdateTradeItemProposals()
        {
            await _tradeItemProposalRepo.UpdateEntitiesAsync(_tradeItemProposals);
        }

        private async Task RemoveExistingTradeItemProposals()
        {
            await GetTradeItemProposalsAsync();
            await _tradeItemProposalRepo.DeleteEntitiesAsync(_tradeItemProposals);
        }

        private void CreateTradeItemProposals()
        {
            _tradeItemProposals = new List<TradeItemProposal>();

            foreach (TradeItemDto TradeItemDto in _tradeItemDTOList)
            {
                _tradeItemProposals.Add(
                    new TradeItemProposal
                    {
                        TradeItemId = TradeItemDto.Id,
                        ProposedAmount = TradeItemDto.ProposedAmount,
                        TradeId = _trade.Id
                    });
            }
        }
    }
}