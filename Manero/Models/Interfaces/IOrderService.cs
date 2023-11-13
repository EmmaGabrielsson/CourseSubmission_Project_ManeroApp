using Manero.Models.Dtos;
using Manero.Models.Entities;

namespace Manero.Models.Interfaces;

public interface IOrderService
{
	Task<Order> GetOrderIfExistAsync();
	Task<OrderEntity> GetOrCreateOrderAsync(Product productViewModel);
	Task<bool> AddOrderRowAsync(Guid orderId, Product addProduct);
	Task<OrderEntity> UpdateOrderWithRowsAsync(OrderEntity order);
}
