using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Shop.BLL.Interfaces;

namespace Shop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<OrderResponseDto>> GetOrdersAsync(CancellationToken token)
    {
        return await orderService.GetOrdersAsync(token);
    }

    [HttpGet("{id:guid}")]
    public async Task<OrderResponseDto> GetOrderById(Guid id, CancellationToken token)
    {
        return await orderService.GetOrderByIdAsync(id, token);
    }

    [HttpGet]
    public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserId([FromBody] Guid userId, CancellationToken token)
    {
        return await orderService.GetOrdersByUserIdAsync(userId, token);
    }

    [HttpPost]
    public async Task CreateOrderAsync([FromBody] OrderRequestCreationDto orderRequest, CancellationToken token)
    {
        await orderService.CreateOrderAsync(orderRequest, token);
    }
}