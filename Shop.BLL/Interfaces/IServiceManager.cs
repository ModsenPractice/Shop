namespace Shop.BLL.Interfaces{
    public interface IServiceManager{ 
        public IGameService GameSerice { get; }
        public ICategoryService CategoryService { get; }
        public IAuthService AuthService { get; }
        public IOrderService OrderService { get; }
        public IOrderItemService OrderItemService { get; }
        public IUserService UserService { get; }
    }
}