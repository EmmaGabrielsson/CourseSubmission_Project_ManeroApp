using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(CodeId))]
public class UserPromocodeEntity
{
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    [ForeignKey(nameof(Promocode))]
    public string CodeId { get; set; } = null!;
    public PromocodeEntity Promocode { get; set; } = null!;
}