using Shop.DAL.Models;
using Shop.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shop.API.Clients;
using Shop.BLL.Common.Configuration;
using Shop.API.Configuration;
using Shop.API.AuthorizationRequirements.Requirements;
using Microsoft.AspNetCore.Authorization;
using Shop.API.AuthorizationRequirements.Handlers;

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

    public static IServiceCollection ConfigureOpenIdDict(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwt = new JwtOptions();
        configuration.GetSection(JwtOptions.Jwt).Bind(jwt);

        var scopes = new ScopesOptions();
        configuration.GetSection(ScopesOptions.Scopes).Bind(scopes);

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

                options.RegisterScopes(scopes.ValidScopes.ToArray());

                options.UseAspNetCore()
                    .EnableAuthorizationEndpointPassthrough()
                    .EnableTokenEndpointPassthrough()
                    .DisableTransportSecurityRequirement();
            })
            .AddValidation(options =>
            {
                options.Configure(conf =>
                {
                    conf.TokenValidationParameters.ValidIssuers = jwt.ValidIssuers;
                });
                options.UseAspNetCore();
                options.UseLocalServer();

                options.AddAudiences(jwt.ValidAudiences.ToArray());
            });


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
            options.DefaultScheme = OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        });

        return services;
    }

    public static IServiceCollection ConfigureAuthPolicies(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>();

        services.AddAuthorizationBuilder()
            .AddPolicy("User", policy =>
                policy.Requirements.Add(new RoleAuthorizationRequirement("user")))
            .AddPolicy("Admin", policy =>
                policy.Requirements.Add(new RoleAuthorizationRequirement("admin")));

        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.Configure<ScopesOptions>(configuration.GetSection(ScopesOptions.Scopes))
            .Configure<ClientsOptions>(configuration.GetSection(ClientsOptions.Clients))
            .Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));
    }
}