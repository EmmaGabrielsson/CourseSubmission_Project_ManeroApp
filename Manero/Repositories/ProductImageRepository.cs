using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class ProductImageRepository : Repo<ProductImageEntity>
{
    public ProductImageRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
