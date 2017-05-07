using AutoMapper;
using Heroes.BusinessLogicLayer.Services;
using Heroes.Data.Mappings;
using Heroes.Data.Models;
using Heroes.DataAccessLayer.GenericRepository;
using Heroes.DataAccessLayer.Models;
using Heroes.DataAccessLayer.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.BusinessLogicLayer.Tests.Services
{
    [TestClass]
    public class PowerServiceTests
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IGenericRepository<Power>> powerRepositoryMock
            = new Mock<IGenericRepository<Power>>();
        private PowerService powerService;

        [TestInitialize]
        public void Initialize()
        {
            unitOfWorkMock.Setup(x => x.GetRepository<Power>())
                .Returns(powerRepositoryMock.Object)
                .Verifiable("should call GetRepository<> of UnitOfWork !!!");

            Mapper.Initialize(option => { option.AddProfile(new DataMappingsProfile()); });

            powerService = new PowerService(unitOfWorkMock.Object);
        }

        [TestMethod]
        public void AddPowerTest()
        {
            //Arrange
            powerRepositoryMock.Setup(x => x.Insert(It.IsAny<Power>()))
                .Verifiable("should insert into repository!!!");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after insert");

            var powerDto = new PowerDTO();

            //Act
            var addedPower = powerService.AddPower(powerDto);

            //Assert
            Assert.IsNotNull(addedPower);
            unitOfWorkMock.Verify();
            powerRepositoryMock.Verify();
        }

        [TestMethod]
        public void PowerExistsTestTrue()
        {
            //Arrange
            var powerId = -1;
            var power = new Power();
            powerRepositoryMock.Setup(x => x.GetById(powerId))
                .Returns(power).Verifiable("should call getById of GenericRepository");

            //Act
            var isExists = powerService.PowerExists(powerId);

            //Assert
            Assert.IsTrue(isExists);
            unitOfWorkMock.Verify();
            powerRepositoryMock.Verify();
        }

        [TestMethod]
        public void PowerExistsTestFalse()
        {
            //Arrange
            var powerId = -1;
            powerRepositoryMock.Setup(x => x.GetById(powerId))
                .Verifiable("should call getById of GenericRepository");

            //Act
            var isExists = powerService.PowerExists(powerId);

            //Assert
            Assert.IsFalse(isExists);
            unitOfWorkMock.Verify();
            powerRepositoryMock.Verify();
        }

        [TestMethod]
        public void DeletePowerTest()
        {
            //Arrange
            var powerId = -1;
            var power = new Power();
            powerRepositoryMock.Setup(x => x.GetById(powerId))
                .Returns(power)
                .Verifiable("should check in repository via GetById");
            powerRepositoryMock.Setup(x => x.Delete(power))
                .Verifiable("should call delete");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after deleting");

            //Act
            var deletedPower = powerService.DeleteHero(powerId);

            //Assert
            Assert.IsNotNull(deletedPower);
            unitOfWorkMock.Verify();
            powerRepositoryMock.Verify();
        }

        [TestMethod]
        public void GetPowersTest()
        {
            //Arrange
            var powers = new List<Power>();
            powerRepositoryMock.Setup(x => x.Get(null))
                .Returns(powers.AsQueryable())
                .Verifiable("should request from repository");

            //Act
            var powerList = powerService.GetPowers(null);

            //Assert
            Assert.IsNotNull(powerList);
            Assert.AreEqual(powerList.Count(), powers.Count);
            powerRepositoryMock.Verify();
            unitOfWorkMock.Verify();
        }

        [TestMethod]
        public void GetPowerByIdTest()
        {
            //Arrange
            var powerId = -1;
            var power = new Power();
            powerRepositoryMock.Setup(x => x.GetById(powerId))
                .Returns(power)
                .Verifiable("should check in repository via GetById");

            //Act
            var powerDto = powerService.GetPowerById(powerId);

            //Assert
            Assert.IsNotNull(powerDto);
            unitOfWorkMock.Verify();
            powerRepositoryMock.Verify();
        }

        [TestMethod]
        public void UpdatePowerTest()
        {
            //Arrange
            var powerDto = new PowerDTO() { ID = -1 };
            var power = new Power();
            powerRepositoryMock.Setup(x => x.GetById(powerDto.ID))
                .Returns(power)
                .Verifiable("should check in repository via GetById");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after update");

            //Act
            powerService.UpdatePower(powerDto);

            //Assert
            unitOfWorkMock.Verify();
            powerRepositoryMock.Verify();
        }
    }
}
