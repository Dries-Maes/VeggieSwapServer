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
    public class TradeFactoryService : ITradeFactoryService
    {
        private TradeRepo _tradeRepo;

        private TradeItemService _tradeItemService;
        private int _trader1Id;
        private int _trader2Id;
        private List<TradeItemProposal> _tradeItemProposals;
        private Trade _trade;
        private List<TradeItemDto> _TradeItemDTOList;
        private IGenericRepo<TradeItemProposal> _tradeItemProposalRepo;

        public TradeFactoryService(TradeRepo tradeRepo, TradeItemService tradeItemService, IGenericRepo<TradeItemProposal> tradeItemProposalRepo, VeggieSwapServerContext context)
        {
            _tradeItemProposalRepo = tradeItemProposalRepo;
            _TradeItemDTOList = new List<TradeItemDto>();
            _tradeItemService = tradeItemService;
            _tradeRepo = tradeRepo;
        }

        public async Task<bool> ControllerPushListAsync(IEnumerable<TradeItemDto> tradeList)
        {
            _TradeItemDTOList = tradeList.ToList();
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

        public async Task<IEnumerable<TradeItemDto>> ControllerGetsList(int userId, int receiverId)
        {
            _trader1Id = userId;
            _trader2Id = receiverId;
            await GetTradeAsync();

            await FetchTradeItemDtoList();

            if (_trade == null)
            {
                return _TradeItemDTOList;
            }
            else
            {
                await GetTradeItemProposalsAsync();
                SetProposedAmounts();
                SetActiveUserId();

                return _TradeItemDTOList;
            }
        }

        public async Task<bool> ControllerAcceptTradeAsync(int userId, int receiverId)
        {
            _trader1Id = userId;
            _trader2Id = receiverId;
            await GetTradeAsync();

            if (_trade != null)
            {
                await FetchTradeItemDtoList();
                await GetTradeItemProposalsAsync();

                foreach (var proposal in _tradeItemProposals)
                {
                    try
                    {
                        _TradeItemDTOList.FirstOrDefault(x => x.Id == proposal.TradeItemId).Amount -= proposal.ProposedAmount;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new ArgumentOutOfRangeException("Insufficiant resources");
                    }
                    catch (Exception)
                    {
                        throw new Exception();
                    }
                }
                await _tradeItemService.UpdateTradeItems(_TradeItemDTOList);
                _trade.Completed = true;
                await _tradeRepo.UpdateEntityAsync(_trade);
                return true;
            }

            return false;
        }

        private void SetProposedAmounts()
        {
            foreach (var proposal in _tradeItemProposals)
            {
                var item = _TradeItemDTOList.FirstOrDefault(x => x.Id == proposal.TradeItemId);

                if (item != null)
                {
                    item.ProposedAmount = proposal.ProposedAmount;
                }
            }
        }

        private void SetActiveUserId()
        {
            foreach (var item in _TradeItemDTOList)
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
                ActiveUserId = _TradeItemDTOList[0].ActiveUserId,
                ProposerId = _TradeItemDTOList[0].ActiveUserId,
                ReceiverId = _TradeItemDTOList[0].ActiveUserId == _trader1Id ? _trader2Id : _trader1Id,
            };
        }

        private async Task FetchTradeItemDtoList()
        {
            _TradeItemDTOList.AddRange(await _tradeItemService.GetTradeItemDetailListDtoAsync(_trader1Id));
            _TradeItemDTOList.AddRange(await _tradeItemService.GetTradeItemDetailListDtoAsync(_trader2Id));
        }

        public void GetUsersId()
        {
            _trader1Id = _TradeItemDTOList[0].UserId;
            _trader2Id = _TradeItemDTOList.FirstOrDefault(x => x.UserId != _trader1Id).UserId;
        }

        public async Task GetTradeAsync()
        {
            _trade = await _tradeRepo.GetTradeAsync(_trader1Id, _trader2Id);
        }

        public async Task GetTradeItemProposalsAsync()
        {
            var values = await _tradeItemProposalRepo.GetAllEntitiesAsync();
            _tradeItemProposals = values.Where(x => x.TradeId == _trade.Id).ToList();
        }

        public async Task UpdateTradeItemProposals()
        {
            await _tradeItemProposalRepo.UpdateEntitiesAsync(_tradeItemProposals);
        }

        public async Task RemoveExistingTradeItemProposals()
        {
            await GetTradeItemProposalsAsync();
            await _tradeItemProposalRepo.DeleteEntitiesAsync(_tradeItemProposals);
        }

        public void CreateTradeItemProposals()
        {
            _tradeItemProposals = new List<TradeItemProposal>();

            foreach (TradeItemDto TradeItemDto in _TradeItemDTOList)
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