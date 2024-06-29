using Shop.DAL.Models;
using Shop.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shop.API.Clients;
using Shop.BLL.Common.Configuration;
using Shop.API.Configuration;

namespace Shop.API.Extensions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<ShopContext>()
            .AddDefaultTokenProviders();
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
                options.SetTokenEndpointUris("api/connect/token", "api/refresh/token");

                options.AllowPasswordFlow()
                    .AllowRefreshTokenFlow();

                options.AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate()
                    .DisableAccessTokenEncryption();

                options.RegisterScopes("api.shop.games");

                options.UseAspNetCore()
                    .EnableAuthorizationEndpointPassthrough()
                    .EnableTokenEndpointPassthrough()
                    .DisableTransportSecurityRequirement();
            });

        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.Configure<ScopesOptions>(configuration.GetSection(ScopesOptions.Scopes))
            .Configure<ClientsOptions>(configuration.GetSection(ClientsOptions.Clients));
    }
}