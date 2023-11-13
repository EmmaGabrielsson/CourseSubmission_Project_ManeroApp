using Manero.Models.Entities;
using Manero.ViewModels;

namespace Manero.Models.Interfaces;

public interface IAddressService
{
	Task<AddressViewModel> GetUserAddressesByUserIdAsync(string id);
	Task<bool> AddUserAddressAsync(AddAddressViewModel viewModel);
	Task<AdressEntity> CreateOrGetAddressAsync(AddAddressViewModel viewModel);
	Task<bool> RemoveUserAddressAsync(AddressViewModel viewModel);
}
