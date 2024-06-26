using Shop.DAL.Models;
using Shop.DAL.Contexts;
using Microsoft.AspNetCore.Identity;

namespace Shop.API.Extensions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ShopContext>();
        return services; 
    }
}