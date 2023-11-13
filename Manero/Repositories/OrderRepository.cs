using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Manero.Repositories;

public class OrderRepository : Repo<OrderEntity>, IOrderRepository
{
    private readonly DataContext _context;
    public OrderRepository(DataContext dataContext, DataContext context) : base(dataContext)
    {
        _context = context;
    }

    public override async Task<OrderEntity> GetAsync(Expression<Func<OrderEntity, bool>> expression)
    {
        try
        {
            var order = await _context.Orders
               .Include(x => x.OrderRows).ThenInclude(x => x.ProductVariant).ThenInclude(x=> x.Color)
               .Include(x => x.OrderRows).ThenInclude(x => x.ProductVariant).ThenInclude(x => x.Size)
               .Include(x => x.Promocode)
               .FirstOrDefaultAsync(expression);

            if (order != null)
                return order;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

}
