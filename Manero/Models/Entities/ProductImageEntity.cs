using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(ImageId))]
public class ProductImageEntity
{
    [ForeignKey(nameof(Product))]
    public string ProductId { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;

    [ForeignKey(nameof(Image))]
    public Guid ImageId { get; set; }
    public ImageEntity Image { get; set; } = null!;

}