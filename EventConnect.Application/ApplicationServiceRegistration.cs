using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventConnect.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //looking for the entire Assembly , any thing that is inheriting from Profile
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}