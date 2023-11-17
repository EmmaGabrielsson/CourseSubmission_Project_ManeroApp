using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class ProductTagRepository : Repo<ProductTagEntity>, IProductTagRepository
{
    public ProductTagRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
