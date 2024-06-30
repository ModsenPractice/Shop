namespace Shop.DAL.Interfaces;

public interface IUnitOfWork
{
    public IGameRepository GameRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IOrderItemRepository OrderItemRepository { get; }

    public Task SaveChangesAsync(CancellationToken cancellationToken);
}