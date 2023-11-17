using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class PromocodeRepository : Repo<PromocodeEntity>, IPromocodeRepository
{
    public PromocodeRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
