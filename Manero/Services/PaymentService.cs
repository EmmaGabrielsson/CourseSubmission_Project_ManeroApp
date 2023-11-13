using Manero.Contexts;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manero.Services
{
    public class PaymentService
    {
        private readonly DataContext _context;

        public PaymentService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public List<PaymentMethodEntity> GetUserPaymentMethods(string userId)
        {
            return _context.UserPaymentMethods
                .Where(upm => upm.UserId == userId)
                .Select(upm => upm.PaymentMethod)
                .ToList();
        }

        public void AddPaymentMethod(PaymentMethodEntity paymentMethod, string userId)
        {
            var userPaymentMethod = new UserPaymentMethodsEntity
            {
                UserId = userId,
                PaymentMethod = paymentMethod
            };

            _context.UserPaymentMethods.Add(userPaymentMethod);
            _context.SaveChanges();
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
        public async Task DeletePaymentMethodAsync(Guid paymentMethodId, string userId)
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
            }
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
}
