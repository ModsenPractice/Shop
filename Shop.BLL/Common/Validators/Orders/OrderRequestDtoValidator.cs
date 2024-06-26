using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Common.Validators.Orders
{
    public abstract class OrderRequestDtoValidator<T> :
        AbstractValidator<T> where T : OrderRequestDto
    {
        public OrderRequestDtoValidator()
        {
            //If user valid should be checked in services
            RuleFor(o => o.UserId).NotEmpty();
        }
    }
}