using AutoFixture;
using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SuperHeroAPI.Controllers;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;
using Xunit.Abstractions;

namespace SuperHeroAPI.Test.IntegrationTests
{
    public class SuperHeroControllerTest
    {
        private readonly IFixture _ifxture;
        private readonly Mock<ISuperHeroService> _superheroServiceMock; //Mocking real superhero service
        private readonly SuperHeroController _superHeroTestController;

        public SuperHeroControllerTest()
        {
            _ifxture = new Fixture();
            _superheroServiceMock = new Mock<ISuperHeroService>();
            _superHeroTestController = new SuperHeroController(_superheroServiceMock.Object);
        }

        //Test Get Superhero by id
        [Fact]
        public  async Task GetSuperheroByIdNotBeNull()
        {
            //Arrange
            var superheroMockData = _ifxture.Create<SuperHero>();
            var id = _ifxture.Create<int>();
            
            //Act
            var result = await _superHeroTestController.GetSingleHero(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<SuperHero>>();
            _superheroServiceMock.Verify(x => x.GetSingleHero(id), Times.Once());
        }

        //Test get all superheroes
        [Fact]
        public async Task GetAllHeroesTest()
        {
            //Arrange
            var result = await _superHeroTestController.GetAllHeroes().ConfigureAwait(false);

            Assert.NotNull(result);
            result.Should().BeOfType<ActionResult<List<SuperHero>>>();
            _superheroServiceMock.Verify(x => x.GetAllHeroes(), Times.Once());
        }

        //Test delete heroes
        [Fact]
        public async Task DeleteSuperheroTest()
        {
            //Arrange
            var superheroId = _ifxture.Create<int>();

            //Act
            var result = await _superHeroTestController.DeleteHero(superheroId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<List<SuperHero>>>();
            _superheroServiceMock.Verify(x => x.DeleteHero(superheroId), Times.Once());
        }

        //Test Update hero
        [Fact]
        public async Task UpdateSuperheroTest()
        {
            //Arrange
            var id = _ifxture.Create<int>();
            SuperHero superhero = new SuperHero(id, "Name", "FirstName", "LastName", "Place", true);

            //Act
            var result = await _superHeroTestController.UpdateHero(id, superhero);


            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<List<SuperHero>>>();
            _superheroServiceMock.Verify(x => x.UpdateHero(id, superhero), Times.Once());

        }

        //Test Add hero
        [Fact]
        public async Task AddHeroShouldReturnListOfHeroes()
        {
            //Arrange
            SuperHero superhero = new SuperHero(_ifxture.Create<int>(), "Name", "FirstName", "LastName", "Place", true);

            //Act
            var result = await _superHeroTestController.AddHero(superhero);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<List<SuperHero>>>();
            _superheroServiceMock.Verify(x => x.AddHero(superhero), Times.Once());
        }

    }
}
