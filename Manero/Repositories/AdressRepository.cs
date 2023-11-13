using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class AdressRepository : Repo<AdressEntity>, IAdressRepository
{
    public AdressRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
