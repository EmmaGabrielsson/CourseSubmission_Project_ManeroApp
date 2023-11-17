using Manero.Models.Entities;
using Manero.Models.Interfaces;
using System.Diagnostics;

namespace Manero.Models.Dtos;

public class Order : IOrder
{
    public Guid Id { get; set; }
    public DateTime? Created { get; set; } = DateTime.Now;
    public string? UserId { get; set; }
    public int? TotalQuantity { get; set; }
    public string? PromocodeId { get; set; }
    public PromocodeEntity? Promocode { get; set; }
    public decimal? SubtotalPrice { get; set; }
    public decimal? DeliveryPrice { get; set; }
    public decimal? TotalPrice { get; set; }
    public ICollection<OrderRowEntity> OrderRows { get; set; } = new HashSet<OrderRowEntity>();
    public bool ProceedToCheckout { get; set; } = false;

    public static implicit operator Order(OrderEntity entity)
    {
        try
        {
            var order = new Order
            {
                Id = entity.Id,
                Created = entity.Created,
                UserId = entity.UserId,
                TotalQuantity = entity.TotalQuantity,
                PromocodeId = entity.PromocodeId,
                Promocode = entity.Promocode,
                SubtotalPrice = entity.SubtotalPrice,
                DeliveryPrice = entity.DeliveryPrice,
                TotalPrice = entity.TotalPrice,
                OrderRows = entity.OrderRows
            };
            return order;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

}
