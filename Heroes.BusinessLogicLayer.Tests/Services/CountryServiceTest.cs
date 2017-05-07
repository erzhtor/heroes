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
    public class CountryServiceTests
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IGenericRepository<Country>> countryRepositoryMock
            = new Mock<IGenericRepository<Country>>();
        private CountryService countryService;

        [TestInitialize]
        public void Initialize()
        {
            unitOfWorkMock.Setup(x => x.GetRepository<Country>())
                .Returns(countryRepositoryMock.Object)
                .Verifiable("should call GetRepository<> of UnitOfWork !!!");

            Mapper.Initialize(option => { option.AddProfile(new DataMappingsProfile()); });

            countryService = new CountryService(unitOfWorkMock.Object);
        }

        [TestMethod]
        [Owner("Erzhan Torokulov")]
        public void AddCountryTest()
        {
            //Arrange
            countryRepositoryMock.Setup(x => x.Insert(It.IsAny<Country>()))
                .Verifiable("should call Insert of GenericRepository!!!");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should call save of UnitOfWork");

            var countryDto = new CountryDTO();

            //Act
            var countryDtoResult = countryService.AddCountry(countryDto);

            //Assert
            Assert.IsNotNull(countryDtoResult);
            unitOfWorkMock.Verify();
            countryRepositoryMock.Verify();
        }

        [TestMethod]
        public void CountryExistsTestTrue()
        {
            //Arrange
            var countryId = -1;
            var country = new Country();
            countryRepositoryMock.Setup(x => x.GetById(countryId))
                .Returns(country).Verifiable("should call getById of GenericRepository");

            //Act
            var result = countryService.CountryExists(countryId);

            //Assert
            Assert.IsTrue(result);
            unitOfWorkMock.Verify();
            countryRepositoryMock.Verify();
        }

        [TestMethod]
        public void CountryExistsTestFalse()
        {
            //Arrange
            var countryId = -1;
            countryRepositoryMock.Setup(x => x.GetById(countryId))
                .Verifiable("should call getById of GenericRepository");

            //Act
            var result = countryService.CountryExists(countryId);

            //Assert
            Assert.IsFalse(result);
            unitOfWorkMock.Verify();
            countryRepositoryMock.Verify();
        }

        [TestMethod]
        public void DeleteCountryTest()
        {
            //Arrange
            var countryId = -1;
            var country = new Country();
            countryRepositoryMock.Setup(x => x.GetById(countryId))
                .Returns(country)
                .Verifiable("should check in repository via GetById");
            countryRepositoryMock.Setup(x => x.Delete(country))
                .Verifiable("should call delete");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after deleting");

            //Act
            var deletedCountry = countryService.DeleteCountry(countryId);

            //Assert
            Assert.IsNotNull(deletedCountry);
            unitOfWorkMock.Verify();
            countryRepositoryMock.Verify();
        }

        [TestMethod]
        public void GetCountriesTest()
        {
            //Arrange
            var countries = new List<Country>();
            countryRepositoryMock.Setup(x => x.Get(null))
                .Returns(countries.AsQueryable())
                .Verifiable("should request from repository");

            //Act
            var result = countryService.GetCountries(null);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), countries.Count);
            countryRepositoryMock.Verify();
            unitOfWorkMock.Verify();
        }

        [TestMethod]
        public void GetCountryByIdTest()
        {
            //Arrange
            var countryId = -1;
            var country = new Country();
            countryRepositoryMock.Setup(x => x.GetById(countryId))
                .Returns(country)
                .Verifiable("should check in repository via GetById");

            //Act
            var result = countryService.GetCountryById(countryId);

            //Assert
            Assert.IsNotNull(result);
            unitOfWorkMock.Verify();
            countryRepositoryMock.Verify();
        }

        [TestMethod]
        public void UpdateCountryTest()
        {
            //Arrange
            var countryDto = new CountryDTO() { ID = -1};
            var country = new Country();
            countryRepositoryMock.Setup(x => x.GetById(countryDto.ID))
                .Returns(country)
                .Verifiable("should check in repository via GetById");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after update");

            //Act
            countryService.UpdateCountry(countryDto);

            //Assert
            unitOfWorkMock.Verify();
            countryRepositoryMock.Verify();
        }
    }
}
