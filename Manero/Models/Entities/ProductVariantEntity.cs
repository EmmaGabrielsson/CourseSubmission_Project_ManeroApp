using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class ProductVariantEntity
{
    public Guid Id { get; set; }
    public string ProductArticleNumber { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;

    [ForeignKey("Size")]
    public int SizeId { get; set; }
    public SizeEntity Size { get; set; } = null!;

    [ForeignKey("Color")]
    public int ColorId { get; set; }
    public ColorEntity Color { get; set; } = null!;

    public int Quantity { get; set; }

}
