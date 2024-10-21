using NotificationService.Infrastructure;

namespace NotificationService.APIs;

public class NotificationLogsService : NotificationLogsServiceBase
{
    public NotificationLogsService(NotificationServiceDbContext context)
        : base(context) { }
}
