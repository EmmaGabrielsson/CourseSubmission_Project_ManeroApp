using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Entities;

public class ProductReviewEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public int Rating { get; set; }
    public string? Comment { get; set; }

    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    [ForeignKey(nameof(ProductArticleNumber))]
    public string ProductArticleNumber { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
}
