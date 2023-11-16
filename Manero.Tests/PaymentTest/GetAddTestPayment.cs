using System;
using System.Threading.Tasks;
using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Manero.Tests.PaymentTest;

public class GetAddTestPayment
{
    [Fact]
    public async Task AddPaymentMethod_ShouldAddToDatabase()
    {
        // Arrange
        using var context = CreateTestDbContext();
        var paymentService = new PaymentService(context);

        var userId = "testUserId";
        var paymentMethod = new PaymentMethodEntity
        {
            CVV = "123",
            CardHolderName = "John Doe",
            CardNumber = "1234567890123456"
            // Add other relevant properties
        };

        // Act
        await paymentService.AddPaymentMethod(paymentMethod, userId);

        // Assert
        var userPaymentMethod = await context.UserPaymentMethods
            .Include(upm => upm.PaymentMethod)
            .FirstOrDefaultAsync(upm => upm.UserId == userId);

        Assert.NotNull(userPaymentMethod);
        Assert.NotNull(userPaymentMethod.PaymentMethod);
        Assert.Equal(paymentMethod.CardNumber, userPaymentMethod.PaymentMethod.CardNumber);
        // Add more assertions as needed
    }

    [Fact]
    public void GetPaymentMethod_ShouldRetrieveFromDatabase()
    {
        // Arrange
        using var context = CreateTestDbContext();
        var paymentService = new PaymentService(context);

        var userId = "testUserId";
        var paymentMethod = new PaymentMethodEntity
        {
            CVV = "123",
            CardHolderName = "John Doe",
            CardNumber = "1234567890123456"
            // Add other relevant properties
        };

        paymentService.AddPaymentMethod(paymentMethod, userId).Wait();

        // Act
        var result = paymentService.GetPaymentMethod(paymentMethod.Id, userId);

        // Assert
        var userPaymentMethod = context.UserPaymentMethods
            .Include(upm => upm.PaymentMethod)
            .FirstOrDefault(upm => upm.UserId == userId);

        Assert.NotNull(userPaymentMethod);
        Assert.NotNull(userPaymentMethod.PaymentMethod);
        Assert.Equal(paymentMethod.CardNumber, userPaymentMethod.PaymentMethod.CardNumber);
    }

    // Add more integration tests for other methods in PaymentService as needed

    private DataContext CreateTestDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase") 
            .Options;

        var context = new DataContext(options);

        return context;
    }
}
