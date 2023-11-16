using Manero.Models.Entities;

namespace Manero.Models.Interfaces;

public interface IOrder
{
	public Guid Id { get; set; }
	public DateTime? Created { get; set; }
	public string? UserId { get; set; }
	public int? TotalQuantity { get; set; }
	public string? PromocodeId { get; set; }
	public PromocodeEntity? Promocode { get; set; }
	public decimal? SubtotalPrice { get; set; }
	public decimal? DeliveryPrice { get; set; }
	public decimal? TotalPrice { get; set; }
    public ICollection<OrderRowEntity> OrderRows { get; set; }

}
