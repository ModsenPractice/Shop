using Microsoft.Extensions.DependencyInjection;

namespace Shop.BLL; 

public static class BllServiceCollectionExtention
{
    public static IServiceCollection ConfigureBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BllServiceCollectionExtention).Assembly); 
        return services;
    }
}