using Manero.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class OrderEntity : IOrderEntity
{
    public Guid Id { get; set; }
    public DateTime? Created { get; set; } = DateTime.Now;
    public string UserId { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public string? PromocodeId { get; set; }
    public PromocodeEntity? Promocode { get; set; }

    [Column(TypeName = "money")]
    public decimal SubtotalPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal DeliveryPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }
    public ICollection<OrderRowEntity> OrderRows { get; set; } = new HashSet<OrderRowEntity>();
}
