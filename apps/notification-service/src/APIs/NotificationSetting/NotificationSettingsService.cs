using NotificationService.Infrastructure;

namespace NotificationService.APIs;

public class NotificationSettingsService : NotificationSettingsServiceBase
{
    public NotificationSettingsService(NotificationServiceDbContext context)
        : base(context) { }
}
