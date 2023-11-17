using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Repositories;
using Manero.Services;
using Microsoft.EntityFrameworkCore;

namespace Manero.Tests;
public class ProductServiceTests
{
    [Fact]
    public async Task WhenGetAsyncMethodCalled_Should_ReturnProduct()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new DataContext(options);
        var productRepository = new ProductRepository(context);

        var sampleProduct = new ProductEntity { ArticleNumber = "1", ProductName = "Product1" };
        context.Products.Add(sampleProduct);
        context.SaveChanges();

        // Act
        var result = await productRepository.GetAsync(x => x.ArticleNumber == "1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(sampleProduct, result);
    }

    [Fact]
    public async Task WhenGetProductByTagAsyncMethodCalled_Should_returnProductsWithTheSpecificTag()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new DataContext(options);

        var tagName = "new";
        var sampleTag = new TagEntity { Id = 1, TagName = tagName };
        var sampleProduct = new ProductEntity { ArticleNumber = "3", ProductName = "Product3" };
        sampleProduct.Tags.Add(new ProductTagEntity { Tag = sampleTag });

        context.Products.Add(sampleProduct);
        context.SaveChanges();

        var tagRepository = new TagRepository(context);

        // Act
        var productRepository = new ProductRepository(context);
        var productService = new ProductService(tagRepository, productRepository, null!, null!);
        var result = await productService.GetProductsByTagAsync(tagName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(sampleProduct, result.First());
    }

    [Fact]
    public async Task WhenGetBestSellingProductsAsyncMethodCalled_Should_returnProductsWithQuantityLessThan2()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new DataContext(options);

        var lowQuantityProduct = new ProductEntity
        {
            ArticleNumber = "5",
            ProductName = "LowQuantityProduct",
            ProductVariants = new List<ProductVariantEntity>
        {
            new ProductVariantEntity { Quantity = 1 }
        }
        };

        context.Products.Add(lowQuantityProduct);
        context.SaveChanges();

        // Act
        var productRepository = new ProductRepository(context);
        var productService = new ProductService(null!, productRepository, null!, null!);
        var result = await productService.GetBestSellingProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(lowQuantityProduct, result.First());
    }

    [Fact]
    public async Task WhenGetSaleProductsAsyncMethodCalled_Should_returnProductsWhereDiscountNotNull()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new DataContext(options);

        var discountedProduct = new ProductEntity
        {
            ArticleNumber = "10",
            ProductName = "DiscountedProduct",
            Discount = 19.99m 
        };

        context.Products.Add(discountedProduct);
        context.SaveChanges();

        // Act
        var productRepository = new ProductRepository(context);
        var productService = new ProductService(null!, productRepository, null!, null!);
        var result = await productService.GetSaleProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(discountedProduct, result.First());
    }
}
