using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;
using Shop.DAL.Models;

namespace Shop.DAL.Repositories
{
    public class OrderItemsRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemsRepository(ShopContext context) : base(context) { }

        public override async Task<IEnumerable<OrderItem>> GetRange(
            Expression<Func<OrderItem, bool>> condition,
            CancellationToken cancellationToken)
        {
            return await _context.OrderItems
                .Where(condition)
                .Include(oi => oi.Game)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}