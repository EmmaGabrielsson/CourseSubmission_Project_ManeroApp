using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class CategoryRepository : Repo<CategoryEntity> , ICategoryRepository
{
    public CategoryRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
