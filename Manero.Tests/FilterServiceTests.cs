using Manero.Models.Entities;
using Manero.Models;
using Manero.Repositories;
using Manero.Services;
using Moq;
using System.Linq.Expressions;
using Manero.Models.Interfaces;

namespace Manero.Tests;

public class FilterServiceTests
{
    [Fact]
    public async Task GetFilteredProductsAsync_ReturnsFilteredProducts_ByTag_BySize_ByCategory_ByMinAndMaxPrice_ByColor()
    {
        // Arrange
        var mockTagRepo = new Mock<ITagRepository>();
        var mockProductRepo = new Mock<IProductRepository>();
        var mockImageRepo = new Mock<IImageRepository>();

        var service = new ProductService(mockTagRepo.Object, mockProductRepo.Object, mockImageRepo.Object);

        var filter = new ProductFilterModel
        {
            TagIds = new List<int> { 1, 2, 3 } ,
            CategoryIds = new List<int> { 1,2, 3 } ,
            Sizes = new List<int> { 1,3, 4 } ,
            Colors = new List<int> { 1,4, 5 } ,
            MinPrice = 45,
            MaxPrice = 100,
            
        };

        mockProductRepo.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
              .ReturnsAsync(new List<ProductEntity>
              {
                   new ProductEntity {
                       Tags = new List<ProductTagEntity> {
                           new ProductTagEntity { TagId = 1 },
                           new ProductTagEntity { TagId = 2 }
                       },
                       Price = 5,
                       Categories = new List<ProductCategoryEntity> { 
                           new ProductCategoryEntity {  CategoryId = 1 }, 
                           new ProductCategoryEntity { CategoryId = 5 } 
                       },
                       ProductVariants = new List<ProductVariantEntity> { 
                           new ProductVariantEntity { ColorId = 1 }, 
                           new ProductVariantEntity {  SizeId = 2 } 
                       }
                   }
              });

        // Act
        var products = await service.GetFilteredProductsAsync(filter);

        // Assert
        Assert.All(products, product =>
        {
            Assert.Contains(product.Tags, tag => filter.TagIds.Contains(tag.TagId));
            Assert.Contains(product.Categories, category => filter.CategoryIds.Contains(category.CategoryId));
            Assert.Contains(product.ProductVariants, variant => filter.Sizes.Contains(variant.SizeId) || filter.Colors.Contains(variant.ColorId));
        });
        Assert.True(products.Any());
    }
    [Fact]
    public async Task GetFilteredProductsAsync_ReturnsProducts_WithinPriceRange()
    {
        // Arrange
        var mockTagRepo = new Mock<ITagRepository>();
        var mockProductRepo = new Mock<IProductRepository>();
        var mockImageRepo = new Mock<IImageRepository>();
        var service = new ProductService(mockTagRepo.Object, mockProductRepo.Object, mockImageRepo.Object);

        var filter = new ProductFilterModel
        {
            MinPrice = 50,
            MaxPrice = 100
        };

        var mockProducts = new List<ProductEntity>
    {
        new ProductEntity { Price = 60 },
        new ProductEntity { Price = 80 },
        new ProductEntity { Price = 40 },
        new ProductEntity { Price = 120 }
    };

        mockProductRepo.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
       .ReturnsAsync(new List<ProductEntity>
       {
                   new ProductEntity { Price = 60 },
                   new ProductEntity { Price = 80 },
       });

        // Act
        var products = await service.GetFilteredProductsAsync(filter);

        // Assert
        Assert.All(products, product => Assert.InRange(product.Price, filter.MinPrice.Value, filter.MaxPrice.Value));
        Assert.DoesNotContain(products, product => product.Price < filter.MinPrice.Value);
        Assert.DoesNotContain(products, product => product.Price > filter.MaxPrice.Value);
    }


}
