using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Repositories;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Manero.Controllers
{
    public class ProductController : Controller
    {

        #region Private Fields & Constructors
        
        private readonly ProductReviewRepository _productReviewRepo;     
        private readonly ProductRepository _productRepository;
        private readonly OrderService _orderService;

        public ProductController(ProductRepository productRepository, OrderService orderService, ProductReviewRepository productReviewRepo)
        {
            _productRepository = productRepository;
            _orderService = orderService;
            _productReviewRepo = productReviewRepo;
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
        
        #region Cart (https://domain.com/product/cart)
        public async Task<IActionResult> Cart()
        {
            ViewData["Title"] = "Your Cart";

            var _order = await _orderService.GetOrderIfExistAsync();

            return View(_order);

        }
        #endregion
        

        public IActionResult Wishlist()
        {
            return View();
        }

        public async Task<IActionResult> Reviews(string id)
        {
            //var reviews = _productReviewRepo.GetReviewsByProductArticleNumberAsync(id);
            var productWithReviews = await _productRepository.GetAsync(x => x.ArticleNumber == id);
            return View(productWithReviews);
        }
    }
}
