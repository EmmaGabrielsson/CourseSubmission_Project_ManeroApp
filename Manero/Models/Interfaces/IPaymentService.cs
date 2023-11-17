using Manero.Models.Entities;
using System.Security.Claims;

namespace Manero.Models.Interfaces;

public interface IPaymentService
{
    IQueryable<UserPaymentMethodsEntity> GetUserPaymentMethodsQuery(string userId);
    List<PaymentMethodEntity> GetUserPaymentMethods(string userId);
    Task<bool> DeletePaymentMethodAsync(Guid paymentMethodId, string userId);
    Task UpdatePaymentMethod(Guid paymentMethodId, string newCardNumber, string userId);
    Task AddPaymentMethod(PaymentMethodEntity paymentMethod, string userId);
    // Add the new methods from PaymentService
    PaymentMethodEntity GetPaymentMethod(Guid paymentMethodId, string userId);


}

