using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnionArchitecture.Core.Domain;
using OnionArchitecture.Core.Repository;

namespace OnionArchitecture.Tests.Core.Service
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CreateUser_Sets_CreatedDate()
        {
            //arrange
            var uowMock = new Mock<IUnitOfWork>();
            var userRepoMock = new Mock<IGenericRepository<User>>();


            //act

            //assert
        }
    }
}
