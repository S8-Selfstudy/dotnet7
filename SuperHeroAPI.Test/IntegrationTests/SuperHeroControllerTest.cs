using AutoFixture;
using FluentAssertions;
using Moq;
using SuperHeroAPI.Controllers;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public  async Task GetSuperheroById()
        {
            //Arrange
            var superheroMockData = _ifxture.Create<SuperHero>();
            var id = _ifxture.Create<int>();
            
            //Act
            var result = await _superHeroTestController.GetSingleHero(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            _superheroServiceMock.Verify(x => x.GetSingleHero(id), Times.Once());
        }

        //Test get all superheroes
        [Fact]
        public async Task GetAllHeroesTest()
        {
            //Arrange
            var result = await _superHeroTestController.GetAllHeroes().ConfigureAwait(false);

            Assert.NotNull(result);
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
            _superheroServiceMock.Verify(x => x.DeleteHero(superheroId), Times.Once());
        }

    }
}
