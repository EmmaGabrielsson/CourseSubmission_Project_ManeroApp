using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Claims;

namespace Manero.Services;

public class AddressService : IAddressService
{
    #region Private Fields & Constructor 

    private readonly IAdressRepository _adressRepository;
    private readonly IUserAdressRepository _userAdressRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

	public AddressService(IAdressRepository adressRepository, IUserAdressRepository userAdressRepository, IHttpContextAccessor httpContextAccessor)
	{
		_adressRepository = adressRepository;
		_userAdressRepository = userAdressRepository;
		_httpContextAccessor = httpContextAccessor;
	}

	#endregion


	public async Task<AddressViewModel> GetUserAddressesByUserIdAsync(string id)
    {
        try
        {
            var _userAdressIds = await _userAdressRepository.GetAllAsync(x => x.UserId == id);
            if (_userAdressIds != null)
            {
                var _userAdresses = new List<AdressEntity>();

                foreach (var item in _userAdressIds)
                {
                    var _address = await _adressRepository.GetAsync(x => x.Id == item.AdressId);
                    if (_address != null)
                        _userAdresses.Add(_address);
                }

                if (!_userAdresses.IsNullOrEmpty())
                {
                    AddressViewModel updatedViewModel = new()
                    {
                        Addresses = _userAdresses,
                        UserId = id,
                        RemoveUserAddressId = null,
                        UserAddressIds = (List<UserAdressEntity>)_userAdressIds
                    };

                    return updatedViewModel;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<bool> AddUserAddressAsync(AddAddressViewModel viewModel)
    {
        try
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim != null)
            {
                var address = await CreateOrGetAddressAsync(viewModel); 
                if (address != null)
                {
                    UserAdressEntity userAdress = new()
                    {
                        UserId = userIdClaim.Value,
                        AdressId = address.Id,
                        Title = viewModel.Title,
                    };

                    var addUserAdress = await _userAdressRepository.CreateAsync(userAdress);
                    if (addUserAdress != null)
                        return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false!;
    }
    public async Task<AdressEntity> CreateOrGetAddressAsync(AddAddressViewModel viewModel)
    {
        try
        {
            var addressExist = await _adressRepository.GetAsync(x => x.StreetName.ToLower() == viewModel.StreetName.ToLower() && x.PostalCode.ToLower() == viewModel.PostalCode.ToLower() && x.City.ToLower() == viewModel.City.ToLower());
            if (addressExist != null)
                return addressExist;
            else
                return await _adressRepository.CreateAsync(viewModel);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }


    public async Task<bool> RemoveUserAddressAsync(AddressViewModel viewModel)
    {
        try
        {
            var userAddress = await _userAdressRepository.GetAsync(x => x.UserId == viewModel.UserId && x.AdressId == viewModel.RemoveUserAddressId);
            if (userAddress != null)
            {
                var result = await _userAdressRepository.DeleteAsync(userAddress);

                var usedAdress = await _userAdressRepository.GetAllAsync(x => x.AdressId == viewModel.RemoveUserAddressId);
                if (!usedAdress.Any())
                {
                    var removeUnusedAddress = await _adressRepository.GetAsync(x => x.Id == viewModel.RemoveUserAddressId);
                    if (removeUnusedAddress != null)
                        await _adressRepository.DeleteAsync(removeUnusedAddress);
                }

                return result;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}
