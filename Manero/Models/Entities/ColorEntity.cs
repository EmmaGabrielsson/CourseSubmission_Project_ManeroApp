using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class ColorEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(25)")]
    public string ColorName { get; set; } = null!;

    [Column(TypeName = "nvarchar(25)")]
    public string ColorCode { get; set; } = null!;
}
