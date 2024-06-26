using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;
using Shop.DAL.Models;

namespace Shop.DAL.Repositories
{
    public class OrderItemsRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemsRepository(ShopContext context) : base(context) { }
    }
}