using System;
using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Manero.Tests.PaymentTest;

public class PaymentServiceUnitTests : IDisposable
{
    private readonly DataContext _context;
    private readonly PaymentService _paymentService;

    public PaymentServiceUnitTests()
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
        _context.Dispose();
    }

    [Fact]
    public async Task AddPaymentMethod_ShouldAddToDatabase()
    {
        // Arrange
        var userId = "testUserId";
        var paymentMethod = new PaymentMethodEntity
        {
            CVV = "123",
            CardHolderName = "John Doe",
            CardNumber = "1234567890123456"
            // Add other relevant properties
        };

        // Act
        await _paymentService.AddPaymentMethod(paymentMethod, userId);

        // Assert
        var userPaymentMethod = _context.UserPaymentMethods
            .Include(upm => upm.PaymentMethod)
            .FirstOrDefault(upm => upm.UserId == userId);

        Assert.NotNull(userPaymentMethod);
        Assert.NotNull(userPaymentMethod.PaymentMethod);
        Assert.Equal(paymentMethod.CardNumber, userPaymentMethod.PaymentMethod.CardNumber);
        // Add more assertions as needed
    }

   
}
