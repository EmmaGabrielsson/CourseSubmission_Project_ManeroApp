using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Column(TypeName = "money")]
    public decimal? Discount { get; set; }

    [Column(TypeName = "nvarchar(5)")]
    public string StandardCurrency { get; set; } = "USD";

    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();
    public ICollection<ProductImageEntity> Images { get; set; } = new HashSet<ProductImageEntity>();
    public ICollection<ProductReviewEntity> Reviews { get; set; } = new HashSet<ProductReviewEntity>();
    public ICollection<ProductVariantEntity> ProductVariants { get; set; } = new HashSet<ProductVariantEntity>();

}
