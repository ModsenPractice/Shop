using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interfaces;

namespace Shop.API.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class OrderitemController : ControllerBase
    {
        private readonly IOrderItemService _orderitems;

        public OrderitemController(IOrderItemService orderitems)
        {
            _orderitems = orderitems;
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetByOrderId(Guid id, CancellationToken cancellationToken)
        {
            var orderitems = await _orderitems.GetOrderItemsByOrderIdAsync(id, cancellationToken);

            return Ok(orderitems);
        }

        [HttpGet("game/{id}")]
        public async Task<IActionResult> GetByGameId(Guid id, CancellationToken cancellationToken)
        {
            var orderitems = await _orderitems.GetOrderItemsByGameIdAsync(id, cancellationToken);

            return Ok(orderitems);
        }
    }
}