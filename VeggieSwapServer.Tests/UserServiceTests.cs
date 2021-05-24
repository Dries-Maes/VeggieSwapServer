using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Configuration;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Tests
{
    public class UserServiceTests
    {
        private User _user;
        private Mock<IUserRepo> _userRepo;
        private Mock<IGenericRepo<User>> _genericRepoUser;
        private Mock<IGenericRepo<Address>> _addresRepo;     
        private List<User> _userList;

        [SetUp]
        public void Setup()
        {
            _userRepo = new Mock<IUserRepo>();
            _genericRepoUser = new Mock<IGenericRepo<User>>();
            _addresRepo = new Mock<IGenericRepo<Address>>();
            _userList = new List<User>();

            _user = new User
            {
                FirstName = "testje",
                LastName = "metZijnGeelVestje", 
                Email = "testje@mail.com",
                ImageUrl = "tesje.jpeg",
                IsAdmin = false
            };

            for (var i = 0; i < 5; i++)
            {
                _userList.Add(_user);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetUserByIdReturnsMappedDto(int id)
        {
            _userRepo.Setup(repo => repo.GetUserAsync(1)).ReturnsAsync(_user);
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());
            UserService userService = new UserService(_genericRepoUser.Object, config.CreateMapper(), _userRepo.Object, _addresRepo.Object);

            UserDto result = await userService.GetUserAsync(1);   
            Assert.AreEqual(result.FirstName, _user.FirstName);
            Assert.AreEqual(result.LastName, _user.LastName);
            Assert.AreEqual(result.Email, _user.Email);
            Assert.AreEqual(result.ImageUrl, _user.ImageUrl);
        }

        [Test]
        public async Task GetUsersReturnsValidListOfUsers()
        {
            _genericRepoUser.Setup(repo => repo.GetAllEntitiesAsync()).ReturnsAsync(_userList);
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());
            UserService userService = new UserService(_genericRepoUser.Object, config.CreateMapper(), _userRepo.Object, _addresRepo.Object);

            List<UserDto> result = (List<UserDto>)await userService.GetAllEntitiesAsync(false);
            Assert.AreEqual(_userList.Count, result.Count);
            Assert.AreEqual(_userList[0].Id, result[0].Id);

            foreach (var item in result)
            {
                Assert.IsNotNull(item);
            }

        }

    }
}