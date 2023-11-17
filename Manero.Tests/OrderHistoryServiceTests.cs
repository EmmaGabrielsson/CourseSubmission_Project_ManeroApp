using Manero.Contexts;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Tests;

public class OrderHistoryServiceTests
{

    [Fact]
    public async Task GetOrdersAsync_ReturnsEmptyList_WhenNoOrdersExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var arrangeContext = new DataContext(options);

        using var testContext = new DataContext(options);
        var service = new OrderHistoryService(null!, testContext);

        // Act
        var result = await service.GetOrdersAsync("testUserId");

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetOrdersAsync_ReturnsOrdersForLoggedInUser()
    {
        // Arrange
        var userId = "testUserId";

        var user = new UserEntity
        {
            Id = userId,
            FirstName = "John",
            LastName = "Doe",
        };

        var orders = new List<CheckoutEntity>
            {
                new CheckoutEntity
                {
                    Order = new OrderEntity
                    {
                        UserId = userId,
                    },
                    StatusCode = new StatusCodeEntity
                    {
                        StatusName = "Delivered",
                    }
                },
            };

        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

        using (var context = new DataContext(options))
        {
            context.Users.Add(user);
            context.CheckoutEntities.AddRange(orders);
            context.SaveChanges();
        }

        var mockContext = new DataContext(options);

        var service = new OrderHistoryService(null!, mockContext);

        // Act
        var result = await service.GetOrdersAsync(userId);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void OrderHistoryViewModel_SetsPropertiesCorrectly()
    {
        // Arrange
        var expectedId = Guid.NewGuid();
        var expectedCreatedDate = DateTime.Now;
        var expectedStatus = "Delivered";
        var expectedUpdateStatusDate = DateTime.Now;
        var expectedTotalPrice = (decimal)49.99;
        var expectedProductArticleNumber = "TEST123";
        var expectedQuantity = 1;
        var expectedProductPrice = (decimal)19.99;

        // Act
        var viewModel = new OrderHistoryViewModel
        {
            Id = expectedId,
            Created = expectedCreatedDate,
            Status = expectedStatus,
            UpdateStatusDate = expectedUpdateStatusDate,
            TotalPrice = expectedTotalPrice,
            ProductArticleNumber = expectedProductArticleNumber,
            Quantity = expectedQuantity,
            ProductPrice = expectedProductPrice,
            Products = new List<OrderProductViewModel>()
        };

        // Assert
        Assert.Equal(expectedId, viewModel.Id);
        Assert.Equal(expectedCreatedDate, viewModel.Created);
        Assert.Equal(expectedStatus, viewModel.Status);
        Assert.Equal(expectedUpdateStatusDate, viewModel.UpdateStatusDate);
        Assert.Equal(expectedTotalPrice, viewModel.TotalPrice);
        Assert.Equal(expectedProductArticleNumber, viewModel.ProductArticleNumber);
        Assert.Equal(expectedQuantity, viewModel.Quantity);
        Assert.Equal(expectedProductPrice, viewModel.ProductPrice);
    }

    [Fact]
    public async Task GetOrdersAsync_ReturnsAllOrders_ForUserWithMultipleOrders()
    {
        // Arrange
        var userId = "testUserIdWithMultipleOrders";
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabaseForMultipleOrders")
            .Options;

        using (var context = new DataContext(options))
        {
            context.CheckoutEntities.AddRange(
                new CheckoutEntity
                {
                    Order = new OrderEntity { UserId = userId, TotalPrice = 100.00m },
                    StatusCode = new StatusCodeEntity { StatusName = "Delivered" }
                },
                new CheckoutEntity
                {
                    Order = new OrderEntity { UserId = userId, TotalPrice = 200.00m },
                    StatusCode = new StatusCodeEntity { StatusName = "Shipped" }
                }

            );
            context.SaveChanges();
        }

        using (var context = new DataContext(options))
        {
            var service = new OrderHistoryService(null!, context);

            // Act
            var result = await service.GetOrdersAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
