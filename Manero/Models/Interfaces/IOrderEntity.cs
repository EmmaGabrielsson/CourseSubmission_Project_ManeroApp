using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Interfaces;

public interface IOrderEntity
{
	public Guid Id { get; set; }
	public DateTime? Created { get; set; }
	public string UserId { get; set; }
	public int TotalQuantity { get; set; }
	public string? PromocodeId { get; set; }
	public PromocodeEntity? Promocode { get; set; }

	[Column(TypeName = "money")]
	public decimal SubtotalPrice { get; set; }

	[Column(TypeName = "money")]
	public decimal DeliveryPrice { get; set; }

	[Column(TypeName = "money")]
	public decimal TotalPrice { get; set; }
	public ICollection<OrderRowEntity> OrderRows { get; set; }

}
