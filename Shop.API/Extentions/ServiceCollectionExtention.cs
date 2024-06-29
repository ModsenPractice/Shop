using Shop.DAL.Models;
using Shop.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shop.API.Clients;

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

    public static IServiceCollection ConfigureOpenIdDict(this IServiceCollection services)
    {
        services.AddHostedService<PostmanClient>();

        services.AddOpenIddict()
            .AddCore(options =>
            {
                options.UseEntityFrameworkCore()
                    .UseDbContext<ShopContext>();
            })
            .AddServer(options =>
            {
                options.SetTokenEndpointUris("api/connect/token");

                options.AllowPasswordFlow()
                    .AllowRefreshTokenFlow();

                options.AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate();

                options.UseAspNetCore()
                    .EnableAuthorizationEndpointPassthrough()
                    .EnableTokenEndpointPassthrough();
            });

        return services;
    }
}