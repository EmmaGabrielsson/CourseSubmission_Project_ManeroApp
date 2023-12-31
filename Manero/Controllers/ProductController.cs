﻿using Manero.Models.Dtos;
using Manero.Models.Interfaces;
﻿using Manero.Models;
using Manero.Repositories;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Manero.Controllers
{
    public class ProductController : Controller
    {

        #region Private Fields & Constructors
        
        private readonly IProductRepository _productRepository;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, OrderService orderService, ProductService productService, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _orderService = orderService;
            _productService = productService;
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Product Detailpage (https://domain.com/product/details/articlenumber)
        public async Task<IActionResult> Details(string id)
        {
            ViewData["Title"] = "Details";

            Product product = await _productRepository.GetAsync(x => x.ArticleNumber == id);

            return View(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> Details(Product productViewModel)
        {
            ViewData["Title"] = "Details";

            if (productViewModel != null && productViewModel.ArticleNumber != null && !productViewModel.SelectedVariantId.ToString().IsNullOrEmpty() && productViewModel.SelectedVariantQuantity != 0)
            {
                var order = await _orderService.GetOrCreateOrderAsync(productViewModel);

                if (order != null)
                    return RedirectToAction("cart", "product");
            }

            Product product = await _productRepository.GetAsync(x => x.ArticleNumber == productViewModel!.ArticleNumber);
            return View(product);
        }

        #endregion
        
        #region Handle Cart (https://domain.com/product/cart)
        public async Task<IActionResult> Cart()
        {
            ViewData["Title"] = "Your Cart";

            var _order = await _orderService.GetOrderIfExistAsync();

            return View(_order);

        }

        [HttpPost]
        public IActionResult Cart(Order order)
        {
            ViewData["Title"] = "Your Cart";

            if(order.ProceedToCheckout == true)
            {
                return RedirectToAction("Checkout", "Order");
            }


            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(string productVariantId, string orderId)
        {
            
            var result = await _orderService.RemoveOrderRowAsync(productVariantId, orderId);

            if(result)
                return Ok(new { success = true, message = "Product removed from the cart." });


            return StatusCode(500, new { success = false, message = "Failed to remove the product from the cart." });
        }


        [HttpPost]
        public async Task<IActionResult> AddPromocode(string promocodeId, string orderId)
        {

            var result = await _orderService.AddPromocodeIdAsync(promocodeId, orderId);

            if (result)
                return Ok(new { success = true, message = "Promocode added to the cart." });


            return StatusCode(500, new { success = false, message = "Failed to add the promocode to cart." });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(string productVariantId, string orderId, int qty)
        {

            var result = await _orderService.UpdateQuantityOfProductInCartAsync(productVariantId, orderId, qty);

            if (result)
                return Ok(new { success = true, message = "Quantity updated." });


            return StatusCode(500, new { success = false, message = "Failed to update quantity of product." });
        }
        #endregion


        public IActionResult Wishlist()
        {
            return View();
        }

        public async Task<IActionResult> Reviews(string id)
        {
            var productWithReviews = await _productRepository.GetAsync(x => x.ArticleNumber == id);
            return View(productWithReviews);
        }

        public async Task<IActionResult> Categories(string categoryName)
        {
            
            var allCategories = await _categoryRepository.GetAllAsync();
            if (allCategories != null)
                ViewBag.ShopWithAllCategories = allCategories;

            if (categoryName != null)
            {
                var products = await _productService.GetAllProductsByCategoryName(categoryName);
                if (products != null)
                {
                    ViewBag.CategoryProducts = products!;
                    ViewBag.ChosenCategory = categoryName;
                }
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Categories(ProductFilterModel filter)
        {
            var allCategories = await _categoryRepository.GetAllAsync();
            if (allCategories != null)
                ViewBag.ShopWithAllCategories = allCategories;

            if (filter.Source == "Categories")
            {
                var filtredProducts = await _productService.GetFilteredProductsAsync(filter);
                if (filtredProducts != null)
                    ViewBag.CategoryProducts = filtredProducts;
                return View();
            }

            return View();

        }
    }
}
