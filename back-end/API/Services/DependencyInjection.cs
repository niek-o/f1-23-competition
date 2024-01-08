using API.Services.Interfaces;

namespace API.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices(configuration);
        services.RegisterAutoMapper();
        return services;
    }

    private static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILapService, LapService>();
        services.AddScoped<IEventService, EventService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }
}

internal interface IMappingProfilesMarker
{
}