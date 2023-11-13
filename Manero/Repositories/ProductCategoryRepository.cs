using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class ProductCategoryRepository : Repo<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
