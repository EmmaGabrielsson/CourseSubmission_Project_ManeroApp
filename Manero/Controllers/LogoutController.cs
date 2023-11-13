using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers;

public class LogoutController : Controller
{
    private readonly SignInManager<UserEntity> _signInManager;

    public LogoutController(SignInManager<UserEntity> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task <IActionResult> Index()
    {
        if(_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Index", "Login");
    }
}
