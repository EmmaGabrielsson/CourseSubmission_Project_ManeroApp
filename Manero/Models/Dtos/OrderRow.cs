using Manero.Models.Entities;
using Manero.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Manero.Models.Dtos;

public class OrderRow : IOrderRow
{
    public Guid OrderId { get; set; }
    public string ProductArticleNumber { get; set; } = null!;
    public Guid ProductVariantId { get; set; }
    public ProductVariantEntity ProductVariant { get; set; } = null!;
    public int Quantity { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal Discount { get; set; } = decimal.Zero;
    public OrderEntity Order { get; set; } = null!;


    public static implicit operator OrderRow(OrderRowEntity entity)
    {
        try
        {
            var row = new OrderRow
            {
                OrderId = entity.OrderId,
                ProductArticleNumber = entity.ProductArticleNumber,
                ProductVariantId = entity.ProductVariantId,
                Quantity = entity.Quantity,
                Discount = (decimal)entity.Discount!,
                Order = entity.Order,
                ProductPrice = entity.ProductPrice
            };
            return row;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
