using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategoryEntity
{
    [ForeignKey(nameof(Product))]
    public string ProductId { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}