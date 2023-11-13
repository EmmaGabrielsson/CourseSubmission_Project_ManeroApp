using Manero.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class AdressEntity : IAdressEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string StreetName { get; set; } = null!;

    [Column(TypeName = "char(5)")]
    public string PostalCode { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string City { get; set; } = null!;

    public ICollection<UserAdressEntity> Users { get; set; } = new HashSet<UserAdressEntity>();
}
