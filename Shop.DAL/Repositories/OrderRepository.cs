using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;
using Shop.DAL.Models;

namespace Shop.DAL.Repositories;

public class OrderRepository(ShopContext context) : BaseRepository<Order>(context), IOrderRepository;