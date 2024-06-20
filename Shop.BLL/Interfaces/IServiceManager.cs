namespace Shop.BLL.Interfaces{
    public interface IServiceManager{ 
        IGameService GameSerice { get; }
        ICategoryService CategoryService { get; }
        IAuthService AuthService { get; }
        IOrderService OrderService { get; }
        IOrderItemService OrderItemService { get; }
        IUserService UserService { get; }
        ITokenService TokenService { get; }
    }
}