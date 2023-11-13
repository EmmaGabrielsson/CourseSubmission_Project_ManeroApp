using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class CheckoutRepository : Repo<CheckoutEntity>
{
    public CheckoutRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
