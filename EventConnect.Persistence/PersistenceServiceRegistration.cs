using EventConnect.Application.Contracts;
using EventConnect.Application.Contracts.Persistance;
using EventConnect.Persistence.DatabaseContext;
using EventConnect.Persistence.Repositoryies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventConnect.Persistence;

public static class  PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EcDataBaseConnectionString");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string 'EcDataBaseConnectionString' is null or empty.");
        }

        services.AddDbContext<EcDatabaseContext>(options =>
        {
            options.UseMySQL(connectionString);
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}