using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using System.Diagnostics;
using System.Security.Claims;

namespace Manero.Services;

public class OrderService : IOrderService
{
    #region Private fields & Constructor

    private readonly IOrderRepository _orderRepository;
    private readonly IOrderRowRepository _orderRowRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPromocodeRepository _promocodeRepository;

    public OrderService(IOrderRepository orderRepository, IOrderRowRepository orderRowRepository, IHttpContextAccessor httpContextAccessor, IPromocodeRepository promocodeRepository)
    {
        _orderRepository = orderRepository;
        _orderRowRepository = orderRowRepository;
        _httpContextAccessor = httpContextAccessor;
        _promocodeRepository = promocodeRepository;
    }

    #endregion

    // Get order if exist
    public async Task<Order> GetOrderIfExistAsync()
    {
        try
        {
            // Get orderId from cookie
            var orderId = _httpContextAccessor.HttpContext!.Request.Cookies["OrderID"];

            OrderEntity order = await _orderRepository.GetAsync(x => x.Id == Guid.Parse(orderId!));
            if (order != null)
            {
                if (order.PromocodeId != null)
                {
                    var updatedOrderWithPromocode = await UpdateOrderWithPromocodeIdAsync(order);
                    if (updatedOrderWithPromocode != null)
                        return updatedOrderWithPromocode!;

                }

                var updatedOrder = await UpdateOrderWithRowsAsync(order);
                if (updatedOrder != null)
                    return updatedOrder;

                return order;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    
    // Get or create the order
    public async Task<OrderEntity> GetOrCreateOrderAsync(Product productViewModel)
    {
        try
        {
            // Get orderId from cookie
            var orderId = _httpContextAccessor.HttpContext!.Request.Cookies["OrderID"];
           
            // Check if User exist and logged in
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            string userId = "";

            if (userIdClaim != null)
                userId = userIdClaim.Value;
            else
                userId = "guest" + orderId!.ToString(); // No user is logged in, or the user ID claim is not present. Use a temp-id for User


            if (Guid.TryParse(orderId, out Guid orderGuid))
            {
                // Search for the order in the database
                OrderEntity order = await _orderRepository.GetAsync(x => x.Id == orderGuid);

                if (order == null)
                {
                    order = new OrderEntity
                    {
                        Id = orderGuid,
                        SubtotalPrice = 0,
                        TotalQuantity = 0,
                        TotalPrice = 0,
                        DeliveryPrice = 0,
                        UserId = userId
                    };

                    await _orderRepository.CreateAsync(order);
                }        
                
                // Add product to orderRow
                if (await AddOrderRowAsync(orderGuid, productViewModel))
                {
                    if(order.PromocodeId != null)
                    {
                        var updatedOrderWithPromocode = await UpdateOrderWithPromocodeIdAsync(order);
                        if (updatedOrderWithPromocode != null)
                            return updatedOrderWithPromocode!;

                    }

                    var updatedOrder = await UpdateOrderWithRowsAsync(order);
                    if (updatedOrder != null)
                        return updatedOrder;
                }             
            }
            else
            {
                // Invalid or missing OrderID in the cookie
            }
          
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
  

    // Add or update orderrow in order for cart and db
    public async Task<bool> AddOrderRowAsync(Guid orderId, Product addProduct)
    {
        try
        {
            OrderRowEntity orderRow = await _orderRowRepository.GetAsync(x => x.OrderId == orderId && x.ProductArticleNumber == addProduct.ArticleNumber && x.ProductVariantId == addProduct.SelectedVariantId);

            if (orderRow != null)
            {
                orderRow.Quantity = addProduct.SelectedVariantQuantity;
                orderRow.ProductVariantId = addProduct.SelectedVariantId;
                var update = await _orderRowRepository.UpdateAsync(orderRow);
                if (update != null)
                    return true;
            }
            else
            {
                orderRow = new OrderRowEntity
                {
                    OrderId = orderId,
                    ProductArticleNumber = addProduct.ArticleNumber!,
                    ProductVariantId = addProduct.SelectedVariantId,
                    ProductPrice = addProduct.Price!,
                    Quantity = addProduct.SelectedVariantQuantity,
                    Discount = addProduct.Discount!
                };

                var created = await _orderRowRepository.CreateAsync(orderRow);
                if (created != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    public async Task<OrderEntity> UpdateOrderWithRowsAsync(OrderEntity order)
    {
        try
        {
            int totalQty = 0;
            decimal totalPrice = 0; 
            decimal totalDiscountPrice = 0; 
            decimal subtotalPrice = 0; 
            decimal deliveryPrice = 0;

            // Check if order has rows and then update it
            var orderRows = await _orderRowRepository.GetAllAsync(x => x.OrderId == order.Id);

            if (orderRows != null && orderRows.Any())
            {
                foreach (var item in orderRows)
                {
                    if (item != null)
                    {
                        totalQty += item.Quantity;
                        subtotalPrice += (item.ProductPrice * item.Quantity);

                        if (item.Discount == 0 || item.Discount == null)
                            totalPrice += (item.ProductPrice * item.Quantity);
                        else
                            totalDiscountPrice += (decimal)item.Discount * item.Quantity;
                    }
                }
            }
            order.SubtotalPrice = subtotalPrice;
            order.TotalPrice = totalPrice + totalDiscountPrice;
            order.TotalQuantity = totalQty;
            order.DeliveryPrice = deliveryPrice;

            var updatedOrder = await _orderRepository.UpdateAsync(order);
            if (updatedOrder != null)
                return updatedOrder;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }


    public async Task<OrderEntity> UpdateOrderWithPromocodeIdAsync(Order order)
    {
        try
        {
            int totalQty = 0;
            decimal totalPrice = 0;
            decimal totalDiscountPrice = 0;
            decimal subtotalPrice = 0;
            decimal deliveryPrice = 0;

            // Check if order has rows and then update it
            var orderRows = await _orderRowRepository.GetAllAsync(x => x.OrderId == order.Id);

            if (orderRows != null && orderRows.Any())
            {
                foreach (var item in orderRows)
                {
                    if (item != null)
                    {
                        totalQty += item.Quantity;
                        subtotalPrice += (item.ProductPrice * item.Quantity);

                        if (item.Discount == 0 || item.Discount == null)
                            totalPrice += (item.ProductPrice * item.Quantity);
                        else
                            totalDiscountPrice += (decimal)item.Discount * item.Quantity;
                    }
                }
            }
            var entity = new OrderEntity()
            {
                Id = order.Id,
                SubtotalPrice = subtotalPrice,
                DeliveryPrice = deliveryPrice,
                TotalPrice = totalPrice + totalDiscountPrice,
                TotalQuantity = totalQty,
                OrderRows = (ICollection<OrderRowEntity>)orderRows!
            };

            var promocode = await _promocodeRepository.GetAsync(x => x.Id == order.PromocodeId);
            entity.PromocodeId = promocode.Id;

            if(promocode.ValidUntilDate >= DateTime.Now)
            {
                entity.TotalPrice = entity.TotalPrice * (1 - promocode.Discount / 100);

                var updatedOrderWithPromoCode = await _orderRepository.UpdateAsync(entity);
                if (updatedOrderWithPromoCode != null)
                    return updatedOrderWithPromoCode;

            }

            var updatedOrder = await _orderRepository.UpdateAsync(entity);
            if (updatedOrder != null)
                return updatedOrder!;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }

    public async Task<bool> RemoveOrderRowAsync(string productVariantId, string orderId)
    {
        try
        {
            var orderRow = await _orderRowRepository.GetAsync(x => x.ProductVariantId == Guid.Parse(productVariantId) && x.OrderId == Guid.Parse(orderId));
            
            if (orderRow != null)
            {
                var result = await _orderRowRepository.DeleteAsync(orderRow);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return false;
    }

    public async Task<bool> AddPromocodeIdAsync(string promocodeId, string orderId)
    {
        try
        {
            OrderEntity order = await _orderRepository.GetAsync(x => x.Id == Guid.Parse(orderId));

            if (order != null)
            {
                var promocode = await _promocodeRepository.GetAsync(x => x.Id == promocodeId.Trim());
                if (promocode != null && promocode.ValidUntilDate >= DateTime.Now)
                {
                    order.PromocodeId = promocode.Id;
                    var result = await _orderRepository.UpdateAsync(order);
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return false;
    }
}
