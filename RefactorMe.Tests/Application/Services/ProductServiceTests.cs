using Moq;
using RefactorMe.Application.Services;
using RefactorMe.Domain.Entities;
using RefactorMe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RefactorMe.Tests.Application.Services
{
    public class ProductServiceTests
    {
        Mock<IProductRepository> _mockRepo;
        ProductService _sut;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _sut = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public void GetProductsShouldReturnListOfGuids()
        {
            // Arrange
            var guids = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            _mockRepo.Setup(p => p.GetProducts()).Returns(guids);

            // Act
            var res = _sut.GetProducts().ToList();

            // Assert
            Assert.Equal(3, res.Count);
            Assert.Equal(res[0], guids[0]);
            Assert.Equal(res[1], guids[1]);
            Assert.Equal(res[2], guids[2]);
        }

        [Fact]
        public void GetProductsShouldReturnEmptyListIfNoProductsFound()
        {
            // Arrange
            _mockRepo.Setup(p => p.GetProducts()).Returns(new List<Guid>());

            // Act
            var res = _sut.GetProducts().ToList();

            // Assert
            Assert.NotNull(res);
            Assert.Empty(res);
        }

        [Fact]
        public void CreateProductShouldSaveProductToRepository()
        {
            // Arrange
            var product = new Product
            {
                Name = "My Product",
                Description = "This is my first product",
                Price = 24.99M,
                DeliveryPrice = 2.99M
            };

            // Act
            _sut.CreateProduct(product);

            // Assert
            _mockRepo.Verify(m => m.InsertProduct(product), Times.Once());
        }

        // Plus lots more tests...
    }
}
