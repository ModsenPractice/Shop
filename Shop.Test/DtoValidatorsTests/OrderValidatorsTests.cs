using FluentValidation.TestHelper;
using Shop.BLL.Common.DataTransferObjects.OrderItems;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Shop.BLL.Common.Validators.Orders;

namespace Shop.Test.DtoValidatorsTests
{
    public class OrderValidatorsTests
    {
        private readonly OrderCreationDtoValidation _creationValidaor = new();

        [Theory]
        [MemberData(nameof(GetValidOrders))]
        public void ValidCreationOrder_ShouldNotHaveValidationError(OrderRequestCreationDto order)
        {
            var result = _creationValidaor.TestValidate(order);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(GetInvalidOrders))]
        public void InvalidCreationOrder_ShouldHaveValidationError(
            OrderRequestCreationDto order, string errorField)
        {
            var result = _creationValidaor.TestValidate(order);

            result.ShouldHaveValidationErrorFor(errorField);
        }

        #region Test Data

        public static IEnumerable<object[]> GetInvalidOrders()
        {
            return
            [
                [
                    new OrderRequestCreationDto()
                    {
                        OrderItems =
                        [
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 2
                            },
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 1
                            }
                        ]
                    },
                    nameof(OrderRequestCreationDto.UserId)
                ],
                [
                    new OrderRequestCreationDto()
                    {
                        UserId = Guid.NewGuid(),
                    },
                    nameof(OrderRequestCreationDto.OrderItems)
                ],
                [
                    new OrderRequestCreationDto()
                    {
                        UserId = Guid.NewGuid(),
                        OrderItems =
                        [
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 0
                            }
                        ]
                    },
                    $"{nameof(OrderRequestCreationDto.OrderItems)}[0].{nameof(OrderItemRequestCreationDto.Count)}"
                ]
            ];
        }

        public static IEnumerable<object[]> GetValidOrders()
        {
            return
            [
                [
                    new OrderRequestCreationDto()
                    {
                        UserId = Guid.NewGuid(),
                        OrderItems =
                        [
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 2
                            },
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 1
                            },
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 10
                            }
                        ]
                    }
                ],
                [
                    new OrderRequestCreationDto()
                    {
                        UserId = Guid.NewGuid(),
                        OrderItems =
                        [
                            new()
                            {
                                GameId = Guid.NewGuid(),
                                Count = 1
                            }
                        ]
                    }
                ]
            ];
        }

        #endregion
    }
}