//using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CT.Web.Controllers;
using CT.Data.Models;
using CT.Repo;
using CT.Repo.Repositories;
using CT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using FakeItEasy;

namespace CT.Tests
{
    public class CountriesControllerTests
    {
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(15)]
        public async Task TestGetCountries(int count)
        {
            // Arrange
            var fakeCountries = A.CollectionOfDummy<Country>(count).AsEnumerable();
            var dataStore = A.Fake<INamedService<Country>>();
            A.CallTo(() => dataStore.GetEntity()).Returns(Task.FromResult(fakeCountries));
            var controller = new CountriesController(dataStore);

            // Act
            var result = await controller.GetCountries();

            // Assert
            Xunit.Assert.Equal(count, result.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(53)]
        public void TestGetCountry(int id)
        {
            // Arrange
            int count = 5;
            var fakeCountries = A.CollectionOfFake<Country>(count);
            var dataStore = A.Fake<INamedService<Country>>();
            fakeCountries[0] = new Country { Id = id, Name = string.Empty};
            A.CallTo(() => dataStore.GetEntity(id)).Returns(fakeCountries.Where(e => e.Id == id).FirstOrDefault());
            var controller = new CountriesController(dataStore);

            // Act
            var result = controller.GetCountry(id).Result.Value.Id;

            //Assert
            Assert.Equal(id, result);
        }

        [Theory]
        [InlineData(1, "CNTR1")]
        [InlineData(4, "CNTR2")]
        [InlineData(4, "CNTR3")]
        public void TestPutCountry(int id, string name)
        {
            // Arrange
            int count = 5;
            Country country = new Country { Id = id, Name = name};
            var fakeCountries = A.CollectionOfFake<Country>(count);
            var dataStore = A.Fake<INamedService<Country>>();

            A.CallTo(() => dataStore.GetEntity(id)).Returns(fakeCountries.Where(e => e.Id == id).FirstOrDefault());

            A.CallTo(() => dataStore.InsertEntity(country))
                .Invokes(call => fakeCountries.Add(country))
                .Returns(Task.FromResult(country));

            A.CallTo(() => dataStore.UpdateEntity(country))
                .Invokes(call => fakeCountries.Where(e => e.Id == id).FirstOrDefault().Name = name)
                .Returns(Task.FromResult(country));

            var controller = new CountriesController(dataStore);

            // Act
            var actionResult = controller.PutCountry(id, country);

            //Assert
            Assert.Equal(country.Name, fakeCountries.Where(e => e.Id == id).FirstOrDefault()?.Name);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(34)]
        public void TestDeleteCountry(int id)
        {
            // Arrange
            int count = 5;
            var fakeCountries = A.CollectionOfFake<Country>(count);
            fakeCountries.Add(new Country { Id = id, Name = string.Empty });
            var dataStore = A.Fake<INamedService<Country>>();

            A.CallTo(() => dataStore.GetEntity(id)).Returns(fakeCountries.Where(e => e.Id == id).FirstOrDefault());

            A.CallTo(() => dataStore.DeleteEntity(id))
                .Invokes(call => fakeCountries.Remove(fakeCountries.Where(e => e.Id == id).FirstOrDefault()))
                .Returns(Task.FromResult(id));

            var controller = new CountriesController(dataStore);

            // Act
            var actionResult = controller.DeleteCountry(id);

            //Assert
            Assert.Empty(fakeCountries.Where(e => e.Id == id).Select(e => e));
        }

        [Theory]
        [InlineData(1, "CNTR1")]
        [InlineData(4, "CNTR2")]
        [InlineData(6, "CNTR3")]
        public void TestPostCountry(int id, string name)
        {
            // Arrange
            int count = 5;
            Country country = new Country { Id = id, Name = name };
            var fakeCountries = A.CollectionOfFake<Country>(count);
            var dataStore = A.Fake<INamedService<Country>>();

            A.CallTo(() => dataStore.GetEntity(id)).Returns(fakeCountries.Where(e => e.Id == id).FirstOrDefault());

            A.CallTo(() => dataStore.InsertEntity(country))
                .Invokes(call => fakeCountries.Add(country))
                .Returns(Task.FromResult(country));

            var controller = new CountriesController(dataStore);

            // Act
            var actionResult = controller.PostCountry(country);

            //Assert
            Assert.Equal(country.Name, fakeCountries.Where(e => e.Id == id).FirstOrDefault()?.Name);
        }
    }
}