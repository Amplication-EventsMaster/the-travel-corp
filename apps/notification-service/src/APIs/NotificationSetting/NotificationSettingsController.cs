using Microsoft.AspNetCore.Mvc;

namespace NotificationService.APIs;

[ApiController()]
public class NotificationSettingsController : NotificationSettingsControllerBase
{
    public NotificationSettingsController(INotificationSettingsService service)
        : base(service) { }
}
