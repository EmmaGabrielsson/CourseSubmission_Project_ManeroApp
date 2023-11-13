using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class UserPromocodeRepository : Repo<UserPromocodeEntity>
{
    public UserPromocodeRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
