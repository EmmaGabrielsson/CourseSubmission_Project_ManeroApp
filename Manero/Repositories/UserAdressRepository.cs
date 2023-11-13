using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class UserAdressRepository : Repo<UserAdressEntity>, IUserAdressRepository
{
    public UserAdressRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
