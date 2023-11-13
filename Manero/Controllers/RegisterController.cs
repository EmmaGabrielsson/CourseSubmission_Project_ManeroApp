using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;

        public RegisterController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.FindByNameAsync(viewModel.Email) == null)
                {
                    var result = await _userManager.CreateAsync(viewModel, viewModel.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Success));
                    }
                }

                ModelState.AddModelError("", "A user with the same e-mail address already exists");
            }

            return View(viewModel);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
