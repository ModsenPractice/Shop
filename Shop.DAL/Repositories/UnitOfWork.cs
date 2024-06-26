using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopContext _context; 
    private readonly Lazy<IGameRepository> _gameRepository; 
    private readonly Lazy<ICategoryRepository> _categoryRepository; 
    private readonly Lazy<IOrderRepository> _orderRepository; 
    private readonly Lazy<IOrderItemRepository> _orderItemRepository; 

    public UnitOfWork(ShopContext context)
    {
        _context = context; 
        _gameRepository = new Lazy<IGameRepository>(()=>new GameRepository(_context));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_context));
        _orderItemRepository = new Lazy<IOrderItemRepository>(() => new OrderItemRepository(_context));
    }
    public IGameRepository GameRepository
    {
        get
        {
            return _gameRepository.Value; 
        }
    }

    public IOrderRepository OrderRepository 
    {
        get
        {
            return _orderRepository.Value; 
        }
    }

    public ICategoryRepository CategoryRepository 
    {
        get
        {
            return _categoryRepository.Value; 
        }
    }

    public IOrderItemRepository OrderItemRepository 
    {
        get
        {
            return _orderItemRepository.Value; 
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}