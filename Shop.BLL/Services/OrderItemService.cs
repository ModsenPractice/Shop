using AutoMapper;
using Microsoft.Extensions.Logging;
using Shop.BLL.Common.DataTransferObjects.OrderItems;
using Shop.BLL.Interfaces;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ILogger<OrderItemService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderItemService(ILogger<OrderItemService> logger,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrderItemResponseDto>> GetOrderItemsByGameIdAsync(Guid id,
            CancellationToken cancellationToken)
        {
            var orderItems = await _unitOfWork.OrderItemRepository
                .GetRange(oi => oi.GameId.Equals(id), cancellationToken);

            var orderItemsResponse = _mapper
                .Map<IEnumerable<OrderItemResponseDto>>(orderItems);

            return orderItemsResponse;
        }

        public async Task<IEnumerable<OrderItemResponseDto>> GetOrderItemsByOrderIdAsync(Guid id,
            CancellationToken cancellationToken)
        {
            var orderItems = await _unitOfWork.OrderItemRepository
                .GetRange(oi => oi.OrderId.Equals(id), cancellationToken);

            var orderItemsResponse = _mapper
                .Map<IEnumerable<OrderItemResponseDto>>(orderItems);

            return orderItemsResponse;
        }
    }
}