using Manero.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers;

public class OrderController : Controller
{
    #region Private Fields & Constructor

    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }
    #endregion
    public async Task<IActionResult> Checkout()
    {
        var _order = await _orderService.GetOrderIfExistAsync();

        return View(_order);
    }
}
