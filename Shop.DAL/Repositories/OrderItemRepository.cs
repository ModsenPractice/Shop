using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;
using Shop.DAL.Models;

namespace Shop.DAL.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ShopContext context) : base(context) { }
    }
}