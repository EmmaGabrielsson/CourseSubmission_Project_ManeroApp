using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class PromocodeEntity
{
    public string Id { get; set; } = null!;

    [Column(TypeName = "nvarchar(80)")]
    public string Title { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Discount { get; set; }
    public DateTime ValidUntilDate { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<UserPromocodeEntity> Promocodes { get; set; } = new HashSet<UserPromocodeEntity>();

}
