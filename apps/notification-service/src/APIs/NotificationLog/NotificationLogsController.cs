using Microsoft.AspNetCore.Mvc;

namespace NotificationService.APIs;

[ApiController()]
public class NotificationLogsController : NotificationLogsControllerBase
{
    public NotificationLogsController(INotificationLogsService service)
        : base(service) { }
}
