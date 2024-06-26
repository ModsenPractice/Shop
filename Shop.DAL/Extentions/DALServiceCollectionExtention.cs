using Microsoft.Extensions.DependencyInjection;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;

namespace Shop.DAL.Extentions; 

public static class DALServiceCollectionExtention
{
    public static IServiceCollection ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>(); 
        return services; 
    }
}