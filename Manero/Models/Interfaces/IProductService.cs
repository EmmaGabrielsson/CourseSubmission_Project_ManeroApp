using Manero.Models.Entities;
using Manero.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Manero.Models.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetProductsByTagAsync(string tagName);
    Task<IEnumerable<ProductEntity>> GetBestSellingProductsAsync();
    Task<IEnumerable<ProductEntity>> GetSaleProductsAsync();
    Task<ImageEntity> GetProductsFirstViewImageAsync(string articleNumber);
    Task<IEnumerable<ProductEntity>> GetFilteredProductsAsync(ProductFilterModel filter);
}
