using Manero.Contexts;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.Services;
using Manero.ViewModels;
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
}
