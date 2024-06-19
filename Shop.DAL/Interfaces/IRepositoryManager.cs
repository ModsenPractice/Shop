namespace Shop.DAL.Interfaces;

public interface IRepositoryManager
{
    public IGameRepository GameRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IOrderItemRepository OrderItemRepository { get; }

    public Task SaveChangesAsync();
}