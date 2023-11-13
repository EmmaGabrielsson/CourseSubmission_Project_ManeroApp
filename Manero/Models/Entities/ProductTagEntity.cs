using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(TagId))]
public class ProductTagEntity
{
    [ForeignKey(nameof(Product))]
    public string ProductId { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;

    [ForeignKey(nameof(Tag))]
    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;

}