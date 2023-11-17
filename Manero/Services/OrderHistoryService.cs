using Manero.Contexts;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Manero.Services;

public class OrderHistoryService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly DataContext _context;

    public OrderHistoryService(UserManager<UserEntity> userManager, DataContext dataContext)
    {
        _userManager = userManager;
        _context = dataContext;
    }

    public async Task<List<OrderHistoryViewModel>> GetOrdersAsync(string userId)
    {
        var orders = await _context.CheckoutEntities
            .Where(x => x.Order.UserId == userId)
            .Include(x => x.StatusCode)
            .Include(x => x.Order)
            .Select(x => new OrderHistoryViewModel
            {
                Id = x.OrderId,
                Created = x.Order.Created.HasValue ? x.Order.Created.Value : default,
                Status = x.StatusCode.StatusName,
                UpdateStatusDate = x.UpdateStatusDate,
                TotalPrice = x.Order.TotalPrice,
                Products = x.Order.OrderRows.Select(x => new OrderProductViewModel
                {
                    ProductArticleNumber = x.ProductArticleNumber,
                    Quantity = x.Quantity,
                    ProductPrice = x.ProductPrice,
                }).ToList()
            })
            .ToListAsync();

        return orders;
    }
}
