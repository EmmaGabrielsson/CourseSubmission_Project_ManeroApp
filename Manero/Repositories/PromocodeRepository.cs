using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class PromocodeRepository : Repo<PromocodeEntity>
{
    public PromocodeRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
