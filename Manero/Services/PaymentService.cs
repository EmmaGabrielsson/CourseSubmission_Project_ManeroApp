using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manero.Services;

public class PaymentService : IPaymentService
{
    private readonly DataContext _context;

    public PaymentService(DataContext context)
    {
        _context = context;
    }

    public IQueryable<UserPaymentMethodsEntity> GetUserPaymentMethodsQuery(string userId)
    {
        return _context.UserPaymentMethods.Where(upm => upm.UserId == userId);
    }
    public List<PaymentMethodEntity> GetUserPaymentMethods(string userId)
    {
        var userPaymentMethodsQuery = GetUserPaymentMethodsQuery(userId);

        return userPaymentMethodsQuery
            .Select(upm => upm.PaymentMethod)
            .ToList();
    }
    public async Task AddPaymentMethod(PaymentMethodEntity paymentMethod, string userId)
    {
        if (!IsValidCVV(paymentMethod.CVV))
        {
            // You can throw an exception or handle the invalid CVV in a way that fits your requirements
            throw new ArgumentException("Invalid CVV");
        }
        var userPaymentMethod = new UserPaymentMethodsEntity
        {
            UserId = userId,
            PaymentMethod = paymentMethod
        };

        await _context.UserPaymentMethods.AddAsync(userPaymentMethod).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
    private static bool IsValidCVV(string cvv)
    {
        // Add your CVV validation logic here
        // For example, check if it has the expected length or meets specific criteria
        return !string.IsNullOrWhiteSpace(cvv) && cvv.Length == 3; // Example: CVV should be a non-empty string with a length of 3
    }
    public PaymentMethodEntity GetPaymentMethod(Guid paymentMethodId, string userId)
    {
        var userPaymentMethod = _context.UserPaymentMethods
            .Include(upm => upm.PaymentMethod)
            .FirstOrDefault(upm => upm.PaymentMethod.Id == paymentMethodId && upm.UserId == userId);

        if (userPaymentMethod != null)
        {
            return userPaymentMethod.PaymentMethod;
        }

        return null!; // Handle the case where the payment method is not found for the given user.
    }
    public async Task<bool> DeletePaymentMethodAsync(Guid paymentMethodId, string userId)
    {
        // Find the UserPaymentMethodsEntity that links the user to the payment method
        var userPaymentMethod = await _context.UserPaymentMethods
            .FirstOrDefaultAsync(upm => upm.PaymentMethod.Id == paymentMethodId && upm.UserId == userId);

        if (userPaymentMethod != null)
        {
            // Remove the relationship between the user and the payment method
            _context.UserPaymentMethods.Remove(userPaymentMethod);
            await _context.SaveChangesAsync();

            // Check if the payment method is associated with any other user
            var isPaymentMethodInUse = await _context.UserPaymentMethods.AnyAsync(upm => upm.PaymentMethod.Id == paymentMethodId);

            // If the payment method is not associated with any other user, delete it
            if (!isPaymentMethodInUse)
            {
                var paymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodId);
                if (paymentMethod != null)
                {
                    _context.PaymentMethods.Remove(paymentMethod);
                    await _context.SaveChangesAsync();


                }

            }
            return true;
        }
        return false;
    }

    public async Task UpdatePaymentMethod(Guid paymentMethodId, string newCardNumber, string userId)
    {
        // Update the payment method with the new card number
        var paymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodId);
        if (paymentMethod != null)
        {
            paymentMethod.CardNumber = newCardNumber;
            await _context.SaveChangesAsync(); // Await the changes
        }
    }


}
