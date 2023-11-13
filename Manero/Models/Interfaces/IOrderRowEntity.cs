using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Interfaces;

public interface IOrderRowEntity
{
	[ForeignKey(nameof(Order))]
	public Guid OrderId { get; set; }
	public string ProductArticleNumber { get; set; }
	public Guid ProductVariantId { get; set; }
	public ProductVariantEntity ProductVariant { get; set; }
	public int Quantity { get; set; }

	[Column(TypeName = "money")]
	public decimal ProductPrice { get; set; }

	[Column(TypeName = "money")]
	public decimal? Discount { get; set; }
	public OrderEntity Order { get; set; }
}
