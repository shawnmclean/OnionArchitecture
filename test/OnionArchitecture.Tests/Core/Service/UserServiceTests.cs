using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnionArchitecture.Core.Domain;
using OnionArchitecture.Core.Repository;
using OnionArchitecture.Infrastructure.Service;

namespace OnionArchitecture.Tests.Core.Service
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CreateUser_Sets_CreatedDate_And_Save()
        {
            //arrange
            var uowMock = new Mock<IUnitOfWork>();
            var userRepoMock = new Mock<IGenericRepository<User>>();

            uowMock.Setup(m => m.SaveChanges()).Verifiable();
            userRepoMock.Setup(m => m.Create(It.IsAny<User>()));

            var userService = new UserService(uowMock.Object, userRepoMock.Object);

            //act
            userService.CreateUser(new User());

            //assert
            uowMock.Verify(m => m.SaveChanges(), "Save Changes was not called.");
            userRepoMock.Verify(m => m.Create(It.Is<User>(mo => mo.DateCreated.Day == DateTime.Now.Day)), "Date Created was not set");
        }
    }
}
