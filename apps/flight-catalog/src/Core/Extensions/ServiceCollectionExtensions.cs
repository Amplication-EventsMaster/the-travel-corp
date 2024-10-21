using FlightCatalog.APIs;

namespace FlightCatalog;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAirlinesService, AirlinesService>();
        services.AddScoped<IAirportsService, AirportsService>();
        services.AddScoped<IFlightsService, FlightsService>();
        services.AddScoped<IRoutesService, RoutesService>();
        services.AddScoped<ISchedulesService, SchedulesService>();
        services.AddScoped<ITicketsService, TicketsService>();
    }
}
