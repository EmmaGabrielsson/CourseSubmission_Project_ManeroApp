using Manero.Contexts;
using Microsoft.EntityFrameworkCore;
using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Manero.Services;
using Manero.Models.Interfaces;

namespace Manero.Controllers;

public class AccountController : Controller
{

	#region Private Fields & Constructors

	private readonly UserManager<UserEntity> _userManager;
	private readonly SignInManager<UserEntity> _signInManager;
	private readonly ILogger<AccountController> _logger;
	private readonly EmailService _emailService;
	private readonly AddressService _addressService;
	private readonly IWebHostEnvironment _hostEnvironment;
    private readonly UserService _userService;
    private readonly OrderHistoryService _orderHistoryService;

    public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IWebHostEnvironment hostEnvironment, ILogger<AccountController> logger, EmailService emailService, AddressService addressService, UserService userService, OrderHistoryService orderHistoryService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _emailService = emailService;
        _addressService = addressService;
        _hostEnvironment = hostEnvironment;
        _userService = userService;
        _orderHistoryService = orderHistoryService;
    }

    #endregion

    #region view profile and edit profile
    [Authorize]
    public async Task<IActionResult> Profile(string update)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Index", "Login");
        }

        if (update != null)
        {
            if (update == "updated")
            {
                ViewBag.Message = "yes";
            }
            else if (update == "wrong")
            {
                ViewBag.Message = "no";
            }
        }
        return View(user);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Profile(MyProfileEditViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var updateResult = await _userService.UpdateUserProfile(viewModel, User);

            if (updateResult)
            {
                return RedirectToAction(nameof(Profile), new { update = "updated" });
            }
        }

        return RedirectToAction(nameof(Profile), new { update = "wrong" });
    }
    #endregion

    #region My Address (https://domain.com/account/address)
    [Authorize]
	public async Task<IActionResult> Address()
	{
		ViewData["Title"] = "My adress";

		var user = await _userManager.GetUserAsync(User);
		if(user != null)
		{
			var userAddresses = await _addressService.GetUserAddressesByUserIdAsync(user.Id);
			if (userAddresses != null)
				return View(userAddresses);
		}

		return View();
	}

	[Authorize]
	[HttpPost]
	public async Task<IActionResult> Address(AddressViewModel viewModel)
	{
		ViewData["Title"] = "My adress";

		if (ModelState.IsValid)
		{
			bool removeUserAddress = await _addressService.RemoveUserAddressAsync(viewModel);

			if (removeUserAddress)
			{
				var userAddresses = await _addressService.GetUserAddressesByUserIdAsync(viewModel.UserId);
				if (userAddresses != null)
					return View(userAddresses);
			}
		}
		ModelState.AddModelError("", "something went wrong");
		return View();
	}
	#endregion

	#region Add Address (https://domain.com/account/addaddress)
	[Authorize]
	public IActionResult AddAddress()
	{
		ViewData["Title"] = "Add adress";

		return View();
	}

	[Authorize]
	[HttpPost]
	public async Task<IActionResult> AddAddress(AddAddressViewModel viewModel)
	{
		ViewData["Title"] = "Add adress";

		if (ModelState.IsValid)
		{
			var result = await _addressService.AddUserAddressAsync(viewModel);
			if (result)
			{
				return RedirectToAction("Address", "Account");
			}

			ModelState.AddModelError("", "something went wrong");
			return View(viewModel);
		}

		ModelState.AddModelError("", "Inputfields are not valid");
		return View(viewModel);

	}
	#endregion


	[HttpGet]
	[AllowAnonymous]
	public IActionResult ForgotPassword()
	{
		return View();
	}


	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			var user = await _userManager.FindByEmailAsync(viewModel.Email);
			if (user != null && await _userManager.IsEmailConfirmedAsync(user))
			{
				var token = await _userManager.GeneratePasswordResetTokenAsync(user);
				var passwordResetLink = Url.Action("ResetPassword", "Account",
					new { email = viewModel.Email, token = token! }, Request.Scheme);

				_logger.LogWarning(passwordResetLink);

				await _emailService.SendPasswordResetEmailAsync(viewModel.Email, passwordResetLink!);

				return View("ForgotPasswordConfirmation");
			}

			return View("ForgotPasswordConfirmation");
		}

		return View(viewModel);
	}

	[HttpGet]
	[AllowAnonymous]
	public IActionResult ResetPassword(string token, string email)
	{
		if (token == null || email == null)
		{
			ModelState.AddModelError("", "Invalid password reset token");
		}

		return View();
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			var user = await _userManager.FindByEmailAsync(viewModel.Email);
			if (user != null)
			{
				var result = await _userManager.ResetPasswordAsync(user, viewModel.Token, viewModel.Password);
				if (result.Succeeded)
				{
					return View("ResetPasswordConfirmation");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}

				return View(viewModel);
			}

			return View("ResetPasswordConfirmation");
		}

		return View(viewModel);
	}

    public async Task<IActionResult> Orders()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Challenge();
        }

        var orders = await _orderHistoryService.GetOrdersAsync(user.Id);
        return View(orders);
    }
}
