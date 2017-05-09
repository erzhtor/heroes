using AutoMapper;
using Heroes.BusinessLogicLayer.Services;
using Heroes.Data.Mappings;
using Heroes.Data.Models;
using Heroes.DataAccessLayer.GenericRepository;
using Heroes.DataAccessLayer.Models;
using Heroes.DataAccessLayer.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Heroes.BusinessLogicLayer.Tests.Services
{
    [TestClass]
    public class HeroServiceTests
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IGenericRepository<Hero>> heroRepositoryMock
            = new Mock<IGenericRepository<Hero>>();
        private readonly Mock<IGenericRepository<Power>> powerRepositoryMock
            = new Mock<IGenericRepository<Power>>();
        private HeroService heroService;

        [TestInitialize]
        public void Initialize()
        {
            unitOfWorkMock.Setup(x => x.GetRepository<Hero>())
                .Returns(heroRepositoryMock.Object)
                .Verifiable("should call GetRepository<> of UnitOfWork !!!");
            unitOfWorkMock.Setup(x => x.GetRepository<Power>())
                .Returns(powerRepositoryMock.Object)
                .Verifiable("should call GetRepository<> of UnitOfWork !!!");

            Mapper.Initialize(option => { option.AddProfile(new DataMappingsProfile()); });

            heroService = new HeroService(unitOfWorkMock.Object);
        }

        [TestMethod]
        public void AddHeroTest()
        {
            //Arrange
            var powers = new List<Power>();
            heroRepositoryMock.Setup(x => x.Insert(It.IsAny<Hero>()))
                .Verifiable("should insert into repository!!!");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after insert");
            powerRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Power, bool>>>()))
                .Returns(powers.AsQueryable())
                .Verifiable("should get powers in order to insert");

            var heroDto = new HeroDTO();

            //Act
            var addedHero = heroService.AddHero(heroDto);

            //Assert
            Assert.IsNotNull(addedHero);
            unitOfWorkMock.Verify();
            heroRepositoryMock.Verify();
            powerRepositoryMock.Verify();
        }

        [TestMethod]
        public void HeroExistsTestTrue()
        {
            //Arrange
            var heroId = -1;
            var hero = new Hero();
            heroRepositoryMock.Setup(x => x.GetById(heroId))
                .Returns(hero).Verifiable("should call getById of GenericRepository");

            //Act
            var isExists = heroService.HeroExists(heroId);

            //Assert
            Assert.IsTrue(isExists);
            unitOfWorkMock.Verify();
            heroRepositoryMock.Verify();
        }

        [TestMethod]
        public void HeroExistsTestFalse()
        {
            //Arrange
            var heroId = -1;
            heroRepositoryMock.Setup(x => x.GetById(heroId))
                .Verifiable("should call getById of GenericRepository");

            //Act
            var isExists = heroService.HeroExists(heroId);

            //Assert
            Assert.IsFalse(isExists);
            unitOfWorkMock.Verify();
            heroRepositoryMock.Verify();
        }

        [TestMethod]
        public void DeleteHeroTest()
        {
            //Arrange
            var heroId = -1;
            var hero = new Hero();
            heroRepositoryMock.Setup(x => x.GetById(heroId))
                .Returns(hero)
                .Verifiable("should check in repository via GetById");
            heroRepositoryMock.Setup(x => x.Delete(hero))
                .Verifiable("should call delete");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after deleting");

            //Act
            var deletedHero = heroService.DeleteHero(heroId);

            //Assert
            Assert.IsNotNull(deletedHero);
            unitOfWorkMock.Verify();
            heroRepositoryMock.Verify();
        }

        [TestMethod]
        public void GetHeroesTest()
        {
            //Arrange
            var heroes = new List<Hero>();
            heroRepositoryMock.Setup(x => x.Get(null))
                .Returns(heroes.AsQueryable())
                .Verifiable("should request from repository");

            //Act
            var heroesList = heroService.GetHeroes();

            //Assert
            Assert.IsNotNull(heroesList);
            Assert.AreEqual(heroesList.Count(), heroes.Count);
            heroRepositoryMock.Verify();
            unitOfWorkMock.Verify();
        }

        [TestMethod]
        public void GetHerorByIdTest()
        {
            //Arrange
            var heroId = -1;
            var hero = new Hero();
            heroRepositoryMock.Setup(x => x.GetById(heroId))
                .Returns(hero)
                .Verifiable("should check in repository via GetById");

            //Act
            var heroDto = heroService.GetHeroById(heroId);

            //Assert
            Assert.IsNotNull(heroDto);
            unitOfWorkMock.Verify();
            heroRepositoryMock.Verify();
        }

        [TestMethod]
        public void UpdateHeroTest()
        {
            //Arrange
            var heroDto = new HeroDTO() { ID = -1 };
            var hero = new Hero();
            var powers = new List<Power>();
            heroRepositoryMock.Setup(x => x.GetById(heroDto.ID))
                .Returns(hero)
                .Verifiable("should check in repository via GetById");
            unitOfWorkMock.Setup(x => x.Save())
                .Verifiable("should save after update");
            heroRepositoryMock.Setup(x => x.LoadCollection(It.IsAny<Hero>(), It.IsAny<Expression<Func<Hero, ICollection<Power>>>>()))
                .Verifiable("should load powers collection from repository");
            powerRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Power, bool>>>()))
                .Returns(powers.AsQueryable())
                .Verifiable("should get new powers from repository");
            //Act
            heroService.UpdateHero(heroDto);

            //Assert
            unitOfWorkMock.Verify();
            heroRepositoryMock.Verify();
        }
    }
}
