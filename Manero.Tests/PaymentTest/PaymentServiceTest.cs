using System;
using System.Collections.Generic;
using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Manero.Tests.PaymentTest;

public class PaymentServiceTests : IDisposable
{
    private readonly DataContext _context;

    public PaymentServiceTests()
    {
        // Setup your test environment, e.g., create an in-memory database
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DataContext(options);
    }

    public void Dispose()
    {
        // Clean up resources after tests
        _context.Dispose();
    }

    [Fact]
    public void GetUserPaymentMethods_ShouldReturnPaymentMethods()
    {
        // Arrange
        var userId = "testUserId";

        var existingUserPaymentMethods = new List<UserPaymentMethodsEntity>
            {
                new UserPaymentMethodsEntity
                {
                    UserId = userId,
                    PaymentMethod = new PaymentMethodEntity
                    {
                        CVV = "123",
                        CardHolderName = "John Doe",
                        CardNumber = "1234567890123456"
                        // Add other relevant properties
                    }
                },
                // Add more user payment methods if needed
            };

        _context.UserPaymentMethods.AddRange(existingUserPaymentMethods);
        _context.SaveChanges();

        var paymentService = new PaymentService(_context);

        // Act
        var result = paymentService.GetUserPaymentMethods(userId);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(existingUserPaymentMethods.Count, result.Count);

    }


    // Add more test methods as needed

    [Fact]
    public async Task DeletePaymentMethodAsync_ShouldRemovePaymentMethod()
    {
        // Arrange
        var userId = "testUserId";
        var paymentMethodId = Guid.NewGuid();

        var existingUserPaymentMethod = new UserPaymentMethodsEntity
        {
            UserId = userId,
            PaymentMethod = new PaymentMethodEntity
            {
                Id = paymentMethodId,
                CVV = "123",
                CardHolderName = "John Doe",
                CardNumber = "1234567890123456"
                // Add other relevant properties
            }
        };

        _context.UserPaymentMethods.Add(existingUserPaymentMethod);
        _context.SaveChanges();

        var paymentService = new PaymentService(_context);

        // Act
        await paymentService.DeletePaymentMethodAsync(paymentMethodId, userId);

        // Assert
        var deletedPaymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodId);
        Assert.Null(deletedPaymentMethod); // Ensure the payment method was deleted
    }
    //next test
    [Fact]
    public async Task DeletePaymentMethodAsync_ShouldRemoveRelationshipAndDeleteIfNotInUse()
    {
        // Arrange
        // Arrange
        var userId = "testUserId";
        var paymentMethodId = Guid.NewGuid();  // Generate a new Guid for paymentMethodId

        var existingUserPaymentMethods = new List<UserPaymentMethodsEntity>
        {
            new UserPaymentMethodsEntity
            {
                UserId = userId,
                PaymentMethod = new PaymentMethodEntity
                {
                    CVV = "123",
                    CardHolderName = "John Doe",
                    CardNumber = "1234567890123456"
                    // Add other relevant properties
                }
            },
            // Add more user payment methods if needed
        };

        _context.UserPaymentMethods.AddRange(existingUserPaymentMethods);
        _context.SaveChanges();

        var paymentService = new PaymentService(_context);

        // Act
        await paymentService.DeletePaymentMethodAsync(paymentMethodId, userId);

        
        // Add assertions as needed
        var userPaymentMethods = _context.UserPaymentMethods.ToList();
        var paymentMethod = _context.PaymentMethods.Find(paymentMethodId);

        Assert.DoesNotContain(userPaymentMethods, upm => upm.PaymentMethod.Id == paymentMethodId && upm.UserId == userId);

        if (paymentMethod != null)
        {
            Assert.DoesNotContain(userPaymentMethods, upm => upm.PaymentMethod.Id == paymentMethodId);
            Assert.Null(_context.PaymentMethods.Find(paymentMethodId));
        }
    }
    //next test
    [Fact]
    public async Task UpdatePaymentMethodAsync_ShouldUpdateCardNumber()
    {
        // Arrange
        var userId = "testUserId";
        var paymentMethodId = Guid.NewGuid();
        var newCardNumber = "9876543210987654";

        var existingUserPaymentMethod = new UserPaymentMethodsEntity
        {
            UserId = userId,
            PaymentMethod = new PaymentMethodEntity
            {
                Id = paymentMethodId,
                CVV = "123",
                CardHolderName = "John Doe",
                CardNumber = "1234567890123456"
                // Add other relevant properties
            }
        };

        _context.UserPaymentMethods.Add(existingUserPaymentMethod);
        _context.SaveChanges();

        var paymentService = new PaymentService(_context);

        // Act
        await paymentService.UpdatePaymentMethod(paymentMethodId, newCardNumber, userId);

        // Assert
        var updatedPaymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodId);
        Assert.NotNull(updatedPaymentMethod);
        Assert.Equal(newCardNumber, updatedPaymentMethod.CardNumber);
    }


}
