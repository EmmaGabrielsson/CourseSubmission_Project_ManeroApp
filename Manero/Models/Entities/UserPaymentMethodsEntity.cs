using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(PaymentId))]
public class UserPaymentMethodsEntity
{
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    [ForeignKey(nameof(PaymentMethod))]
    public Guid PaymentId { get; set; }
    public PaymentMethodEntity PaymentMethod { get; set; } = null!;

}
