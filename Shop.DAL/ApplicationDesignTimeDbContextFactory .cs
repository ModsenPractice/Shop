using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shop.DAL.Contexts;

namespace Shop.DAL
{
    public class ApplicationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        //Db user and password should be provided by console
        //e.g.: dotnet ef migrations add "migration" -- user=username passord=password
        public ShopContext CreateDbContext(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Username and password arguments are not provided.");
            }

            var user = args[0];
            var password = args[1];

            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();

            optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=ShopDatabase;Username={user};Password={password};",
                x =>
                {
                    x.MigrationsAssembly(typeof(ShopContext).Assembly.FullName);
                });
            optionsBuilder.UseOpenIddict();

            return new ShopContext(optionsBuilder.Options);
        }
    }

    internal class ConfigurationBuilder
    {
        public ConfigurationBuilder()
        {
        }
    }
}