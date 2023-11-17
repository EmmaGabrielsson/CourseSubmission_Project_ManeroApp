using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace Manero.Controllers
{
    [Authorize] // Apply authorization to secure these actions
    public class PaymentController : Controller
    {

        private readonly IPaymentService _paymentService;
        private readonly UserManager<UserEntity> _userManager;
        readonly IUserService _userService;

        public IUserService UserService => _userService;

        public PaymentController(IPaymentService paymentService, UserManager<UserEntity> userManager, IUserService userService)
        {
            _paymentService = paymentService;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult List()
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user == null)
            {
                return NotFound();
            }

            var paymentMethods = _paymentService.GetUserPaymentMethods(user.Id);
            if (paymentMethods == null || !paymentMethods.Any())
            {
                // You might want to log or handle this case appropriately
                return RedirectToAction("Add");
            }

            var viewModel = new PaymentMethodsViewModel
            {
                PaymentMethods = paymentMethods.Select(pm => new PaymentMethodViewModel
                {
                    Id = pm.Id,
                    CardHolderName = pm.CardHolderName,
                    CardNumber = pm.CardNumber,
                    ExpiryMonth = pm.ExpiryMonth,
                    ExpiryYear = pm.ExpiryYear,
                    CVV = pm.CVV
                }).ToList(),
                UserName = user.UserName!,
                TotalPaymentMethods = paymentMethods.Count
            };

            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(PaymentMethodViewModel paymentMethod)
        {
            if (ModelState.IsValid)
            {
                // Get the current user asynchronously
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound();
                }

                // Create a new PaymentMethodEntity and populate its properties from the view model
                var entity = new PaymentMethodEntity
                {
                    Id = paymentMethod.Id,
                    CardHolderName = paymentMethod.CardHolderName,
                    CardNumber = paymentMethod.CardNumber.Replace(" ", ""),
                    ExpiryMonth = paymentMethod.ExpiryMonth,
                    ExpiryYear = paymentMethod.ExpiryYear,
                    CVV = paymentMethod.CVV
                };

                // Get the user's ID
                var userId = await _userManager.GetUserIdAsync(user);

                // Call the service to add the payment method
                await _paymentService.AddPaymentMethod(entity, userId);

                return RedirectToAction("List");
            }

            return View(paymentMethod);
        }





        public IActionResult Delete(Guid id)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user == null)
            {
                return NotFound();
            }

            var paymentMethod = _paymentService.GetPaymentMethod(id, user.Id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await _paymentService.DeletePaymentMethodAsync(id, user.Id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // Log the exception here, and return an error view
                // return View("Error", new ErrorViewModel { Message = "An error occurred while deleting the payment method." });
                return View("Error");
            }
        }


        public IActionResult GoBack()
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }




        public IActionResult CardDetails(Guid id)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user == null)
            {
                return NotFound();
            }

            var paymentMethod = _paymentService.GetPaymentMethod(id, user.Id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            var viewModel = new PaymentMethodViewModel
            {

                PaymentMethodId = paymentMethod.Id,
                CardHolderName = paymentMethod.CardHolderName,
                CardNumber = paymentMethod.CardNumber,
                ExpiryMonth = paymentMethod.ExpiryMonth,
                ExpiryYear = paymentMethod.ExpiryYear,
                CVV = paymentMethod.CVV
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, string newCardNumber)
        {
            // Get the current user's ID
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Update the payment method with the new card number
            await _paymentService.UpdatePaymentMethod(id, newCardNumber, user.Id);

            // Redirect back to the CardDetails action for the edited card
            return RedirectToAction("CardDetails", new { id = id });
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
