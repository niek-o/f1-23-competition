using Microsoft.EntityFrameworkCore;

namespace API.Database;

public static class DataExtension
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("default");
        
        services.AddDbContext<F1DbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging());

        return services;
    }
}