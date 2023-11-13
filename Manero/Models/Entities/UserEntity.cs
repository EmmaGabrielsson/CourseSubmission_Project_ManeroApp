using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities;

public class UserEntity : IdentityUser
{

    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(40)")]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(40)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(80)")]
    public string? Location { get; set; }
    public string? ProfileImageUrl { get; set; }
    public ICollection<UserAdressEntity> Adresses { get; set; } = new HashSet<UserAdressEntity>();
    public ICollection<UserPromocodeEntity> Promocodes { get; set; } = new HashSet<UserPromocodeEntity>();
    public ICollection<UserPaymentMethodsEntity> PaymentMethods { get; set; } = new HashSet<UserPaymentMethodsEntity>();

}
