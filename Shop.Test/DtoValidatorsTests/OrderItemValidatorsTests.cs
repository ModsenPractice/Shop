using FluentValidation.TestHelper;
using Shop.BLL.Common.DataTransferObjects.OrderItems;
using Shop.BLL.Common.Validators.OrderItems;

namespace Shop.Test.DtoValidatorsTests
{
    public class OrderItemValidatorsTests
    {
        private readonly OrderItemCreationDtoValidator _creationValidator = new();

        [Theory]
        [MemberData(nameof(GetValidOrderItems))]
        public void ValidCreationOrderItem_ShouldNotHaveValidationError(
            OrderItemRequestCreationDto orderItem)
        {
            var result = _creationValidator.TestValidate(orderItem);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(GetInvalidOrderItems))]
        public void InvalidCreationOrderItem_ShouldHaveValidationError(
            OrderItemRequestCreationDto orderItem, string errorField)
        {
            var result = _creationValidator.TestValidate(orderItem);

            result.ShouldHaveValidationErrorFor(errorField);
        }

        #region Test Data

        public static IEnumerable<object[]> GetInvalidOrderItems()
        {
            return
            [
                [
                    new OrderItemRequestCreationDto()
                    {
                        GameId = Guid.NewGuid()
                    },
                    nameof(OrderItemRequestCreationDto.Count)
                ],
                [
                    new OrderItemRequestCreationDto()
                    {
                        GameId = Guid.NewGuid(),
                        Count = -5
                    },
                    nameof(OrderItemRequestCreationDto.Count)
                ],
                [
                    new OrderItemRequestCreationDto()
                    {
                        Count = 2
                    },
                    nameof(OrderItemRequestCreationDto.GameId)
                ],
            ];
        }

        public static IEnumerable<object[]> GetValidOrderItems()
        {
            return
            [
                [
                    new OrderItemRequestCreationDto()
                    {
                        GameId = Guid.NewGuid(),
                        Count = 1
                    }
                ],
                [
                    new OrderItemRequestCreationDto()
                    {
                        GameId = Guid.NewGuid(),
                        Count = 2
                    }
                ]
            ];
        }

        #endregion
    }
}