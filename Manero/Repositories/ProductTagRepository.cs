using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class ProductTagRepository : Repo<ProductTagEntity>
{
    public ProductTagRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
