using System;
using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Manero.Tests.PaymentTest;

public class PaymentUnitTests : IDisposable
{
    private readonly DataContext _context;
    private readonly PaymentService _paymentService;

    public PaymentUnitTests()
    {
        // Setup your test environment, e.g., create an in-memory database
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DataContext(options);
        _paymentService = new PaymentService(_context);
    }

    public void Dispose()
    {
        // Clean up resources after tests
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public async Task AddMultiplePaymentMethods_ShouldAddToDatabase()
    {
        // Arrange
        var userId = "testUserId";
        var paymentMethod1 = new PaymentMethodEntity
        {
            CVV = "123",
            CardHolderName = "John Doe",
            CardNumber = "1234567890123456"
            // Add other relevant properties
        };

        var paymentMethod2 = new PaymentMethodEntity
        {
            CVV = "456",
            CardHolderName = "Jane Doe",
            CardNumber = "6543210987654321"
            // Add other relevant properties
        };

        // Act
        await _paymentService.AddPaymentMethod(paymentMethod1, userId);
        await _paymentService.AddPaymentMethod(paymentMethod2, userId);

        // Assert
        var userPaymentMethods = _context.UserPaymentMethods
            .Include(upm => upm.PaymentMethod)
            .Where(upm => upm.UserId == userId)
            .ToList();

        // Check that both payment methods are added
        Assert.Equal(2, userPaymentMethods.Count);

        // Add more specific assertions for each payment method if needed
        Assert.Contains(userPaymentMethods, upm => upm.PaymentMethod.CardNumber == paymentMethod1.CardNumber);
        Assert.Contains(userPaymentMethods, upm => upm.PaymentMethod.CardNumber == paymentMethod2.CardNumber);
    }

    [Fact]
    public async Task AddPaymentMethod_InvalidCVV_ShouldNotAddToDatabase()
    {
        // Arrange
        var userId = "testUserId";
        var paymentMethod = new PaymentMethodEntity
        {
            CVV = "invalidCVV", // Invalid CVV
            CardHolderName = "John Doe",
            CardNumber = "1234567890123456"
            // Add other relevant properties
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await _paymentService.AddPaymentMethod(paymentMethod, userId));

        // Assert that no payment methods are added to the database
        var userPaymentMethods = _context.UserPaymentMethods
            .Include(upm => upm.PaymentMethod)
            .Where(upm => upm.UserId == userId)
            .ToList();

        Assert.Empty(userPaymentMethods);
    }



}
