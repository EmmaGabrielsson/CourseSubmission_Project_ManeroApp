using Manero.Models.Entities;
using Manero.Repositories;
using System.Linq.Expressions;

namespace Manero.Models.Interfaces;

public interface IProductRepository : IRepo<ProductEntity>
{
    new Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression);
    new Task<IEnumerable<ProductEntity>> GetAllAsync();
    new Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression);
}
