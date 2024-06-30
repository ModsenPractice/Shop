using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Shop.BLL.Interfaces;

namespace Shop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "User")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync(CancellationToken token)
    {
        return Ok(await orderService.GetOrdersAsync(token));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id, CancellationToken token)
    {
        return Ok(await orderService.GetOrderByIdAsync(id, token));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersByUserId([FromBody] Guid userId, CancellationToken token)
    {
        return Ok(await orderService.GetOrdersByUserIdAsync(userId, token));
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task CreateOrderAsync([FromBody] OrderRequestCreationDto orderRequest, CancellationToken token)
    {
        await orderService.CreateOrderAsync(orderRequest, token);
    }
}