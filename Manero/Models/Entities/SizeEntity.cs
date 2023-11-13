using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class SizeEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(6)")]
    public string SizeName { get; set; } = null!;
}
