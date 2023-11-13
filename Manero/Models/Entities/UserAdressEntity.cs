using System.ComponentModel.DataAnnotations.Schema;
using Manero.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AdressId))]
public class UserAdressEntity : IUserAdressEntity
{
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string? Title { get; set; }

    [ForeignKey(nameof(Adress))]
    public int AdressId { get; set; }
    public AdressEntity Adress { get; set; } = null!;
}