using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class UserPaymentMethodsRepository : Repo<UserPaymentMethodsEntity>
{
    public UserPaymentMethodsRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
