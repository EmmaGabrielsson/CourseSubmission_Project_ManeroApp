using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class SizeRepository : Repo<SizeEntity>
{
    public SizeRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
