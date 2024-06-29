using Microsoft.Extensions.DependencyInjection;
using Npgsql.Replication;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using FluentValidation; 

namespace Shop.BLL.Extentions; 

public static class FluentValidationExtention
{
    public static IServiceCollection ConfigureAutoFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(FluentValidationExtention).Assembly);
        services.AddFluentValidationAutoValidation(); 
        return services; 
    }
}