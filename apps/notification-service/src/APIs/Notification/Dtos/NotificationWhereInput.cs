namespace NotificationService.APIs.Dtos;

public class NotificationWhereInput
{
    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<string>? NotificationLogs { get; set; }

    public string? NotificationType { get; set; }

    public string? Title { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UserNotification { get; set; }

    public List<string>? UserNotifications { get; set; }
}
