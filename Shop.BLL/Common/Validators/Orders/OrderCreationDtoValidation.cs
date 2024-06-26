using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Shop.BLL.Common.Validators.OrderItems;

namespace Shop.BLL.Common.Validators.Orders
{
    public class OrderCreationDtoValidation : OrderRequestDtoValidator<OrderRequestCreationDto>
    {
        public OrderCreationDtoValidation()
        {
            RuleFor(o => o.OrderItems).NotEmpty();

            RuleForEach(o => o.OrderItems)
                .SetValidator(new OrderItemCreationDtoValidator());
        }
    }
}