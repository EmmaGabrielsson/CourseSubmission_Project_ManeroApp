using Manero.Models.Entities;

namespace Manero.Models.Interfaces;

public interface IAddressViewModel
{
	public List<UserAdressEntity>? UserAddressIds { get; set; }
	public List<AdressEntity> Addresses { get; set; }
	public string UserId { get; set; } 
	public int? RemoveUserAddressId { get; set; }
}
