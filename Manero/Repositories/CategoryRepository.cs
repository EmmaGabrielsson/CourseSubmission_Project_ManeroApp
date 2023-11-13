using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
