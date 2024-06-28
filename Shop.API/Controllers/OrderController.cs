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
    public async Task<OrderResponseDto> GetOrderById(Guid id)
    {
        return await orderService.GetOrderByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserId([FromBody] Guid userId)
    {
        return await orderService.GetOrdersByUserIdAsync(userId);
    }

    [HttpPost]
    public async Task Post([FromBody] OrderRequestCreationDto orderRequest)
    {
        await orderService.CreateOrderAsync(orderRequest);
    }
}