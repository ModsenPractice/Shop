using Shop.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Shop.DAL
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string? connectionString)
        {
            return services.AddDbContext<ShopContext>(dbOptions =>
            {
                dbOptions.UseNpgsql(connectionString, x =>
                {
                    x.MigrationsAssembly(typeof(ShopContext).Assembly.FullName);
                });

                dbOptions.UseOpenIddict();
            });
        }
    }
}
