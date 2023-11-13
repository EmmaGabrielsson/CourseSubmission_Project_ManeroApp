using Manero.Models.Entities;
using System.Diagnostics;

namespace Manero.Models.Dtos;

public class Product
{
    public string ArticleNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; } = decimal.Zero;
    public string StandardCurrency { get; set; } = null!;
    public Guid SelectedVariantId { get; set; }
    public int SelectedVariantQuantity { get; set; }
    public ICollection<ProductVariantEntity> ProductVariants { get; set; } = new HashSet<ProductVariantEntity>();
    public ICollection<ProductReviewEntity> Reviews { get; set; } = new HashSet<ProductReviewEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();
    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();
    public ICollection<ProductImageEntity> Images { get; set; } = new HashSet<ProductImageEntity>();


    public static implicit operator Product(ProductEntity entity)
    {
        try
        {
            var product = new Product
            {
                ArticleNumber = entity.ArticleNumber,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Price = entity.Price,
                StandardCurrency = entity.StandardCurrency,
                ProductVariants = entity.ProductVariants,
                Reviews = entity.Reviews,
                Tags = entity.Tags,
                Categories = entity.Categories,
                Images = entity.Images,
            };

            if(entity.Discount != null)
                product.Discount = (decimal)entity.Discount;

            return product;

        } catch(Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
