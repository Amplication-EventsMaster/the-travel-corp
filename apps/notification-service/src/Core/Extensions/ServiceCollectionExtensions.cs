using NotificationService.APIs;

namespace NotificationService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationsService, NotificationsService>();
        services.AddScoped<INotificationLogsService, NotificationLogsService>();
        services.AddScoped<INotificationSettingsService, NotificationSettingsService>();
        services.AddScoped<INotificationTypesService, NotificationTypesService>();
        services.AddScoped<IUserNotificationsService, UserNotificationsService>();
    }
}
