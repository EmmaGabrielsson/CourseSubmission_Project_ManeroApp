using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class TagRepository : Repo<TagEntity>
{
    public TagRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
