using System.ComponentModel.DataAnnotations.Schema;
using Manero.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(OrderId), nameof(ProductArticleNumber), nameof(ProductVariantId))]
public class OrderRowEntity : IOrderRowEntity
{
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public string ProductArticleNumber { get; set; } = null!;
    public Guid ProductVariantId { get; set; }
    public ProductVariantEntity ProductVariant { get; set; } = null!;
    public int Quantity { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Discount { get; set; }
    public OrderEntity Order { get; set; } = null!;

}
