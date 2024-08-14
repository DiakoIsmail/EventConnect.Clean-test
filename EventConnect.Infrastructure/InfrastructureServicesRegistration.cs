using EventConnect.Application.Contracts.Logging;
using EventConnect.Infrastructure.LoggerAdapter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventConnect.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
      
     
        services.AddScoped(typeof(IAppLogger), typeof(LoggerAdapter<>));
        
        return services;
    }
}