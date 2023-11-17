using Manero.Contexts;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Manero.Repositories;

public class ProductRepository : Repo<ProductEntity>
{
    private readonly DataContext _dataContext;
    public ProductRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            var product = await _dataContext.Products
               .Include(x => x.Tags).ThenInclude(x => x.Tag)
               .Include(x => x.Images).ThenInclude(x => x.Image)
               .Include(x => x.Categories).ThenInclude(x => x.Category)
               .Include(x => x.Reviews).ThenInclude(x => x.User)
               .Include(x => x.ProductVariants).ThenInclude(x => x.Color)
               .Include(x => x.ProductVariants).ThenInclude(x => x.Size)
               .FirstOrDefaultAsync(expression);

            if (product != null)
                return product;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        try
        {
            var product = await _dataContext.Products
               .Include(x => x.Tags).ThenInclude(x => x.Tag)
               .Include(x => x.Images).ThenInclude(x => x.Image)
               .Include(x => x.Categories).ThenInclude(x => x.Category)
               .Include(x => x.Reviews)
               .Include(x => x.ProductVariants).ThenInclude(x => x.Color)
               .Include(x => x.ProductVariants).ThenInclude(x => x.Size)
               .ToListAsync();

            if (product != null)
                return product;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            var product = await _dataContext.Products
               .Include(x => x.Tags).ThenInclude(x => x.Tag)
               .Include(x => x.Images).ThenInclude(x => x.Image)
               .Include(x => x.Categories).ThenInclude(x => x.Category)
               .Include(x => x.Reviews)
               .Include(x => x.ProductVariants).ThenInclude(x => x.Color)
               .Include(x => x.ProductVariants).ThenInclude(x => x.Size)
               .Where(expression).ToListAsync();

            if (product != null)
                return product;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }



    public async Task<IEnumerable<ProductEntity>> SearchAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            var products = await _dataContext.Products
                .Where(expression)
                .Include(x => x.Tags).ThenInclude(x => x.Tag)
                .Include(x => x.Images).ThenInclude(x => x.Image)
                .Include(x => x.Categories).ThenInclude(x => x.Category)
                .Include(x => x.Reviews).ThenInclude(x => x.User)
                .Include(x => x.ProductVariants).ThenInclude(x => x.Color)
                .Include(x => x.ProductVariants).ThenInclude(x => x.Size)
                .ToListAsync();

            if (products != null)
                return products;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return Enumerable.Empty<ProductEntity>();
    }

}
