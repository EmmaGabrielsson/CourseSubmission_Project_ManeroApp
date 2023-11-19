using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class TagRepository : Repo<TagEntity>, ITagRepository
{
    public TagRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
