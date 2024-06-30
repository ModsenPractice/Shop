using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.BLL.Common.Configuration;
using Shop.BLL.Interfaces;
using Shop.BLL.Services;

namespace Shop.BLL;

public static class BllServiceCollectionExtention
{
    public static IServiceCollection ConfigureBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BllServiceCollectionExtention).Assembly)
            .ConfigureServices();
        return services;
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>()
            .AddScoped<ITokenService, TokenService>();
        return services;
    }
}