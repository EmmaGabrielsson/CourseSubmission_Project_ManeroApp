using Manero.Models.Entities;
using Manero.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;
using LinqKit;
using Manero.Models;
using Manero.Models.Interfaces;

namespace Manero.Services;

public class ProductService : IProductService
{
    #region Private Fields and Constructors

    private readonly TagRepository _tagRepository;
    private readonly ProductRepository _productRepository;
    private readonly ImageRepository _imageRepository;
    private readonly CategoryRepository _categoryRepository;

    public ProductService(TagRepository tagRepository, ProductRepository productRepository, ImageRepository imageRepository, CategoryRepository categoryRepository)
    {
        _tagRepository = tagRepository;
        _productRepository = productRepository;
        _imageRepository = imageRepository;
        _categoryRepository = categoryRepository;
    }

    #endregion
    public async Task<IEnumerable<ProductEntity>> GetProductsByTagAsync(string tagName)
    {
        try
        {
            // Retrieve the products with the specified tagName
            var tag = await _tagRepository.GetAsync(x => x.TagName == tagName);

            if (tag != null)
            {
                var products = await _productRepository.GetAllAsync(x => x.Tags.Any(x => x.TagId == tag.Id));

            return products;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
            return null!;
    }

    public async Task<IEnumerable<ProductEntity>> GetBestSellingProductsAsync()
    {
        try
        {
            // Retrieve the best selling products by checking their low quantity in stock
            var bestSellingProducts = await _productRepository.GetAllAsync(x => x.ProductVariants.Any(x => x.Quantity < 2));

            if (bestSellingProducts != null)
                return bestSellingProducts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public async Task<IEnumerable<ProductEntity>> GetSaleProductsAsync()
    {
        try
        {
            // Retrieve the sale products by checking if they have a discount price
            var saleProducts = await _productRepository.GetAllAsync(x => x.Discount != null);

            if (saleProducts != null)
                return saleProducts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }


    public async Task<ImageEntity> GetProductsFirstViewImageAsync(string articleNumber)
    {
        try
        {
            var extraImage = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3");
            var product = await _productRepository.GetAsync(x => x.ArticleNumber == articleNumber);
            var productImage = product.Images.FirstOrDefault(x => x.ImageId != extraImage);
            var image = await _imageRepository.GetAsync(x => x.Id == productImage!.ImageId);

            if (image != null)
                return image;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    // products filter
    public async Task<IEnumerable<ProductEntity>> GetFilteredProductsAsync(ProductFilterModel filter)
    {
        try {
            Expression<Func<ProductEntity, bool>> expression = x => true;
            if (filter.TagIds != null && filter.TagIds.Any())
            {
                expression = expression.And(x => x.Tags.Any(t => filter.TagIds.Contains(t.Tag.Id)));
            }
            if (filter.Source == "BestSeller")
            {

                if (filter.TagIds == null || filter.TagIds.Count == 0)
                {
                    expression = expression.And(x => x.ProductVariants.Any(x => x.Quantity < 2));
                }
                if (filter.TagIds != null && filter.TagIds.Count >= 1)
                {
                    expression = expression.And(x => x.Tags.Any(t => filter.TagIds.Contains(t.Tag.Id)));
                }
            }
            if (filter.Source == "Sale")
            {
                if (filter.TagIds == null || filter.TagIds.Count == 0)
                {
                    expression = expression.And(x => x.Discount != null);
                }
                if (filter.TagIds != null && filter.TagIds.Count >= 1)
                {
                    expression = expression.And(x => x.Tags.Any(t => filter.TagIds.Contains(t.Tag.Id)));
                }
            }
            if (filter.Source == "FeatuerdProduct")
            {
                if (filter.TagIds == null || filter.TagIds.Count == 0)
                {
                    expression = expression.And(x => x.Tags.Any(x => x.TagId == 2));
                }
                if (filter.TagIds != null && filter.TagIds.Count >= 1)
                {
                    expression = expression.And(x => x.Tags.Any(t => filter.TagIds.Contains(t.Tag.Id)));
                }

            }

            if (filter.Colors != null && filter.Colors.Any())
            {
                expression = expression.And(x => x.ProductVariants.Any(v => filter.Colors.Contains(v.Color.Id)));
            }
            if (filter.Sizes != null && filter.Sizes.Any())
            {
                expression = expression.And(x => x.ProductVariants.Any(v => filter.Sizes.Contains(v.Size.Id)));
            }

            if (filter.MinPrice.HasValue)
            {
                expression = expression.And(x => x.Price >= filter.MinPrice.Value);
            }
            if (filter.MaxPrice.HasValue)
            {
                expression = expression.And(x => x.Price <= filter.MaxPrice.Value);
            }

            if (filter.CategoryIds != null && filter.CategoryIds.Any())
            {
                expression = expression.And(x => x.Categories.Any(c => filter.CategoryIds.Contains(c.Category.Id)));
            }

            return await _productRepository.GetAllAsync(expression);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
        
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsByCategoryName(string categoryName)
    {
        try
        {
            // Retrieve the products with the specified categoryname
            var category = await _categoryRepository.GetAsync(x => x.CategoryName.ToLower() == categoryName.ToLower());

            if (category != null)
            {
                var products = await _productRepository.GetAllAsync(x => x.Categories.Any(x => x.CategoryId == category.Id));

                return products;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

}
