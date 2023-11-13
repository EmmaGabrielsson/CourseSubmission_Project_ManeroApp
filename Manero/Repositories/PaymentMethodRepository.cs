using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class PaymentMethodRepository : Repo<PaymentMethodEntity>
{
    public PaymentMethodRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
