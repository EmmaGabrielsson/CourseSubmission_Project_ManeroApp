using Manero.Models;
using Manero.Models.Interfaces;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Home";

        var bestSellingProducts = await _productService.GetBestSellingProductsAsync();
        if (bestSellingProducts != null)
            ViewBag.BestSellerProducts = bestSellingProducts;

        var featuredProducts = await _productService.GetProductsByTagAsync("new");
        if (featuredProducts != null)
            ViewBag.FeaturedProducts = featuredProducts;

        var saleProducts = await _productService.GetSaleProductsAsync();
        if(saleProducts != null)
            ViewBag.SaleProducts = saleProducts;

        return View();
    }
    public async Task<IActionResult> Sale(ProductFilterModel filter)
    {
        var saleProducts = await _productService.GetSaleProductsAsync();
        if (saleProducts != null)
            ViewBag.SaleProducts = saleProducts;
        if (filter.Source == "Sale")
        {
            var filtredProducts = await _productService.GetFilteredProductsAsync(filter);
            if (filtredProducts != null)
                ViewBag.SaleProducts = filtredProducts;
            return View();
        }

        return View();
    }
    public async Task<IActionResult> BestSeller(ProductFilterModel filter)
    {
        if (filter.Source == "BestSeller")
        {
            var filtredProducts = await _productService.GetFilteredProductsAsync(filter);
            if (filtredProducts != null)
                ViewBag.BestSellerProducts = filtredProducts;

            return View();

        }
        var bestSellingProducts = await _productService.GetBestSellingProductsAsync();
        if (bestSellingProducts != null)
            ViewBag.BestSellerProducts = bestSellingProducts;

        return View();
    }
    public async Task<IActionResult> FeatuerdProduct(ProductFilterModel filter)
    {
        if (filter.Source == "FeatuerdProduct")
        {
            var filtredProducts = await _productService.GetFilteredProductsAsync(filter);
            if (filtredProducts != null)
                ViewBag.FeaturedProducts = filtredProducts;
            return View();
        }
        var featuredProducts = await _productService.GetProductsByTagAsync("new");
        if (featuredProducts != null)
            ViewBag.FeaturedProducts = featuredProducts;

        return View();

    }
   
}
