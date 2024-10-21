namespace NotificationService.APIs.Dtos;

public class NotificationCreateInput
{
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<NotificationLog>? NotificationLogs { get; set; }

    public NotificationType? NotificationType { get; set; }

    public string? Title { get; set; }

    public DateTime UpdatedAt { get; set; }

    public UserNotification? UserNotification { get; set; }

    public List<UserNotification>? UserNotifications { get; set; }
}
