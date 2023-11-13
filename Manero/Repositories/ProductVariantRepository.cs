using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class ProductVariantRepository : Repo<ProductVariantEntity>
{
    public ProductVariantRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
