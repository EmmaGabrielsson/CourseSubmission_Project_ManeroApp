namespace Manero.Models.Entities;

public class CheckoutEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
    public Guid PaymentMethodId { get; set; }
    public PaymentMethodEntity PaymentMethod { get; set; } = null!;
    public int StatusId { get; set; }
    public StatusCodeEntity StatusCode { get; set; } = null!;
    public DateTime UpdateStatusDate { get; set; }

}
