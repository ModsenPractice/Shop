using Shop.DAL.Models;
using Shop.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Shop.API.Extensions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ShopContext>();
        return services; 
    }

    public static IServiceCollection ConfigureLogger(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        services.AddSerilog(); 
        return services; 
    }
}