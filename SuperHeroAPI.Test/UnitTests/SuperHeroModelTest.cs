using AutoFixture;
using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroAPI.Test.UnitTests
{
    public class SuperHeroModelTest
    {
        private readonly IFixture _ifixture = new Fixture();

        [Fact]
        public void ConstructorTest()
        {
            //Arrange
            var id = _ifixture.Create<int>();
            var name = "Test Hero";
            var firstName = "firstName";
            var lastName = "lastName";
            var place = "place";
            var active = true;

            //Act
            SuperHero superhero = new SuperHero(id, name, firstName, lastName, place, active);

            //Assert
            Assert.Equal(id, superhero.Id);
            Assert.Equal(name, superhero.Name);
            Assert.Equal(firstName, superhero.FirstName);
            Assert.Equal(lastName, superhero.LastName);
            Assert.Equal(place, superhero.Place);
            Assert.Equal(active, superhero.Active);
        }
    }
}
