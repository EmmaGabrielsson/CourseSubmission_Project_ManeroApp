using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.ViewModels;

public class AddressViewModel : IAddressViewModel
{
    public List<UserAdressEntity>? UserAddressIds { get; set; }
    public List<AdressEntity> Addresses { get; set; } = new List<AdressEntity>();
    public string UserId { get; set; } = null!;
    public int? RemoveUserAddressId { get; set; }
}
