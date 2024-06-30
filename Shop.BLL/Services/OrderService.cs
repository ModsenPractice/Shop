using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Microsoft.Extensions.Logging;
using Shop.DAL.Interfaces;
using Shop.BLL.Exceptions.NotFoundExceptions;
using Shop.DAL.Models;

namespace Shop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(ILogger<OrderService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersAsync(CancellationToken cancellation)
        {
            var orders = await _unitOfWork.OrderRepository.GetRange(o => true, cancellation);

            if (!orders.Any())
            {
                _logger.LogError("Orders not found exception in method GetOrdersAsync in OrderService");
                throw new NotFoundException("Any orders not found");
            }

            var orderDtos = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return orderDtos;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellation)
        {
            var orders = await _unitOfWork.OrderRepository.GetRange(o => o.UserId == userId, cancellation);

            if (!orders.Any())
            {
                _logger.LogError("Orders with user id not found exception in method GetOrdersByUserIdAsync in OrderService");
                throw new NotFoundException("Any orders with this userId not found");
            }

            var orderDtos = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return orderDtos;
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid id, CancellationToken cancellation)
        {
            var order = await _unitOfWork.OrderRepository.GetSingle(o => o.Id == id, cancellation);

            if (order is null)
            {
                _logger.LogError("Order not found exception in method GetOrderByIdAsync in OrderService");
                throw new NotFoundException($"Any orders with id:{id} not found");
            }

            var orderDto = _mapper.Map<OrderResponseDto>(order);
            return orderDto;
        }

        public async Task CreateOrderAsync(OrderRequestCreationDto orderRequestCreationDto, CancellationToken cancellation)
        {
            var orderModel = _mapper.Map<Order>(orderRequestCreationDto);
            _unitOfWork.OrderRepository.Create(orderModel);
            await _unitOfWork.SaveChangesAsync(cancellation);
        }
    }
}
