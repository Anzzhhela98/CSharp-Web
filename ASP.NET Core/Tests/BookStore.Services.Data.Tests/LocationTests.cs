namespace BookStore.Services.Data.Tests
{
    using System.Linq;

    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Services.Data.Location;
    using BookStore.Web.ViewModels.Location;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class LocationTests
    {
        [Fact]
        public void AllLocationReturnNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AllLocationReturnNull").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            var result = service.AllLocation();

            Assert.Empty(result);
        }

        [Fact]
        public void AllLocationReturnColllection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AllLocationReturnColllection").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 1,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testName@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 3,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testNaaame@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });

            dbContext.SaveChanges();

            var result = service.AllLocation();
            var secondResult = result.FirstOrDefault(x => x.Email == "testName@abv.bg");
            var thirdResult = result.Select(x => x.Id).FirstOrDefault();

            Assert.Contains("testName@abv.bg", secondResult.Email);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void AllLocationReturnOneCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AllLocationReturnOneCount").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 1,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testName@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });
            dbContext.SaveChanges();

            var result = service.AllLocation();
            var secondResult = result.FirstOrDefault(x => x.Email == "testName@abv.bg");
            var thirdResult = result.Select(x => x.Id).FirstOrDefault();

            Assert.Equal(1, thirdResult);
        }

        [Fact]
        public void LocationByIdReturnNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("LocationByIdReturnNull").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 1,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testName@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });
            dbContext.SaveChanges();

            var result = service.LocationById(0);
            var secondResult = service.LocationById(2);
            var thirdtResult = service.LocationById(-1);

            Assert.Null(result);
            Assert.Null(secondResult);
            Assert.Null(thirdtResult);
        }

        [Fact]
        public void LocationByIdReturnCorrect()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("LocationByIdReturnCorrect").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 1,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testName@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });
            dbContext.SaveChanges();

            var result = service.LocationById(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void LocationByIdReturnCorrectData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("LocationByIdReturnCorrectData").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 1,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testName@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });
            dbContext.SaveChanges();

            var result = service.LocationById(1);

            Assert.Equal("testName", result.Name);
        }


        [Fact]
        public void LocationByIdReturnCorrectTypeModel()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("LocationByIdReturnCorrectTypeModel").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new LocationService(dbContext);

            dbContext.StoreLocations.Add(new BookStore.Data.Models.StoreLocation
            {
                Id = 1,
                Name = "testName",
                PhoneNumber = "00000",
                Email = "testName@abv.bg",
                Address = "testAddress",
                Image = "testImage",
            });
            dbContext.SaveChanges();

            var result = service.LocationById(1);

            Assert.IsNotType<StoreLocation>(result);
            Assert.IsType<LocationByIdViewModel>(result);
        }
    }
}
