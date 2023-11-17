using System.Collections.Generic;
using Manero.Controllers;
using Manero.Models;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.Repositories;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace Manero.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Index_Should_returnViewResultWithViewData()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var controller = new HomeController(productServiceMock.Object);

            var bestSellingProducts = new List<ProductEntity>
            {
                new ProductEntity { ArticleNumber = "1", ProductName = "Product1" },
                new ProductEntity { ArticleNumber = "2", ProductName = "Product2" }
            };

            var featuredProducts = new List<ProductEntity>
            {
                new ProductEntity { ArticleNumber = "3", ProductName = "Product3" },
                new ProductEntity { ArticleNumber = "4", ProductName = "Product4" }
            };

            var saleProducts = new List<ProductEntity>
            {
                new ProductEntity { ArticleNumber = "5", ProductName = "Product5" },
                new ProductEntity { ArticleNumber = "6", ProductName = "Product6" }
            };

            productServiceMock.Setup(x => x.GetBestSellingProductsAsync()).ReturnsAsync(bestSellingProducts);
            productServiceMock.Setup(x => x.GetProductsByTagAsync("new")).ReturnsAsync(featuredProducts);
            productServiceMock.Setup(x => x.GetSaleProductsAsync()).ReturnsAsync(saleProducts);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewData = Assert.IsType<ViewDataDictionary>(viewResult.ViewData);

            Assert.True(viewData.ContainsKey("BestSellerProducts"));
            Assert.Equal(bestSellingProducts, viewData["BestSellerProducts"]);

            Assert.True(viewData.ContainsKey("FeaturedProducts"));
            Assert.Equal(featuredProducts, viewData["FeaturedProducts"]);

            Assert.True(viewData.ContainsKey("SaleProducts"));
            Assert.Equal(saleProducts, viewData["SaleProducts"]);
        }

        [Fact]
        public async Task Sale_WithValidFilter_Should_returnViewResultWithViewData()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var controller = new HomeController(productServiceMock.Object);

            var saleProducts = new List<ProductEntity>
            {
             new ProductEntity { ArticleNumber = "5", ProductName = "Product5" },
             new ProductEntity { ArticleNumber = "6", ProductName = "Product6" }
             };

            productServiceMock.Setup(x => x.GetFilteredProductsAsync(It.IsAny<ProductFilterModel>()))
                              .ReturnsAsync((ProductFilterModel filter) =>
                              {
                                  return saleProducts;
                              });

            var filter = new ProductFilterModel
            {
                Source = "Sale",
            };

            // Act
            var result = await controller.Sale(filter);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewData = Assert.IsType<ViewDataDictionary>(viewResult.ViewData);

            Assert.True(viewData.ContainsKey("SaleProducts"));
            Assert.Equal(saleProducts, viewData["SaleProducts"]);
        }
    }
}
