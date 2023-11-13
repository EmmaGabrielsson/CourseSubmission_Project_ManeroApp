using Manero.Models.Entities;
using System.Linq.Expressions;

namespace Manero.Models.Interfaces;

public interface IOrderRepository : IRepo<OrderEntity>
{
	new Task<OrderEntity> GetAsync(Expression<Func<OrderEntity, bool>> expression);
}
