using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class PaymentMethodEntity
{
    public Guid Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string CardHolderName { get; set; } = null!;

    [Column(TypeName = "nvarchar(16)")]
    public string CardNumber { get; set; } = null!;
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }

    [Column(TypeName = "nvarchar(3)")]
    public string CVV { get; set; } = null!;

    public ICollection<UserPaymentMethodsEntity> PaymentMethods { get; set; } = new HashSet<UserPaymentMethodsEntity>();

}
