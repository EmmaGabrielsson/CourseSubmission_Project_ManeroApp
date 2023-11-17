using Manero.Models.Entities;

namespace Manero.Models.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetProductsByTagAsync(string tagName);
        Task<IEnumerable<ProductEntity>> GetBestSellingProductsAsync();
        Task<IEnumerable<ProductEntity>> GetSaleProductsAsync();
        Task<ImageEntity> GetProductsFirstViewImageAsync(string articleNumber);
        Task<IEnumerable<ProductEntity>> GetFilteredProductsAsync(ProductFilterModel filter);
        Task<IEnumerable<ProductEntity>> GetAllProductsByCategoryName(string categoryName);
    }
}
