using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Common.Validators.OrderItems
{
    public abstract class OrderItemRequestDtoValidator<T> :
        AbstractValidator<T> where T : OrderItemRequestDto
    {
        protected const int MIN_COUNT = 1;

        public OrderItemRequestDtoValidator()
        {
            RuleFor(oi => oi.GameId).NotEmpty();

            RuleFor(oi => oi.Count).GreaterThanOrEqualTo(MIN_COUNT);
        }
    }
}