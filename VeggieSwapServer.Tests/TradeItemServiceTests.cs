using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Configuration;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Business.Services;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;


namespace VeggieSwapServer.Tests
{
    public class TradeItemServiceTests
    {
        private TradeItem _tradeItem;
        private Mock<TradeItemRepo> _tradeItemRepo;       
        private Mock<UserRepo> _userRepo;
        private Mock<IGenericRepo<TradeItem>> _genericRepoTradeItem;
        private List<TradeItem> _tradeItemList;

        [SetUp]
        public void Setup()
        {
            _tradeItemRepo = new Mock<TradeItemRepo>();
            _userRepo = new Mock<UserRepo>();           
            _tradeItemList = new List<TradeItem>();
            _genericRepoTradeItem = new Mock<IGenericRepo<TradeItem>>();

            _tradeItem = new TradeItem
            {               
               Amount = 50
            };

            for (var i = 0; i < 5; i++)
            {
                _tradeItemList.Add(_tradeItem);
            }
        }
                
        public async Task GetAllEntitiesAsyncReturnsValidListOfTradeItems()
        {
            _tradeItemRepo.Setup(repo => repo.GetAllEntitiesAsync()).ReturnsAsync(_tradeItemList);
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());
            TradeItemService tradeItemService = new TradeItemService(_tradeItemRepo.Object, _userRepo.Object, config.CreateMapper());            

            List<TradeItemDto> result = (List<TradeItemDto>)await tradeItemService.GetAllEntitiesAsync();
            Assert.AreEqual(_tradeItemList.Count, result.Count);
            Assert.AreEqual(_tradeItemList[0].Id, result[0].Id);

            foreach (var item in result)
            {
                Assert.IsNotNull(item);
            }
        }
               
    }
}
