using FarmMarket.Data;
using FarmMarket.Data.Model;
using FarmMarket.Service.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmMarket.Tests.Service
{
    public class FarmProductServiceTests
    {
        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.FarmProducts.CountAsync() <= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    dbContext.FarmProducts.Add(
                        new FarmProduct()
                        {
                            Id = Guid.NewGuid(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "Yam",
                            Description = "10 tubers of yam on display",
                            Unit = 10,
                            Amount = 300  
                        }
                    );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;
        }

        [Fact]
        public async void FarmProductServiceTest_AddFarmProduct_ReturnsCreatedProduct()
        {
            //Arrange
            var product = new FarmProduct()
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                Name = "Beans",
                Description = "20 sweet beans on display",
                Unit = 100,
                Amount = 700
            };
            var dbContext = await GetDatabaseContext();
            var productService = new FarmProductService(dbContext);

            //Act
            var result = productService.AddFarmProduct(product);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
