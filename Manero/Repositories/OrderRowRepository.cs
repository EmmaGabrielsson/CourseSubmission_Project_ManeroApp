using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class OrderRowRepository : Repo<OrderRowEntity>, IOrderRowRepository
{
    public OrderRowRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
