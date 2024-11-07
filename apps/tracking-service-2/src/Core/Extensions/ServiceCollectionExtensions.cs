using TrackingService_2.APIs;

namespace TrackingService_2;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<ITrackingsService, TrackingsService>();
    }
}
