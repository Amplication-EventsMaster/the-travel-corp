namespace NotificationService.APIs.Dtos;

public class UserNotificationCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Message { get; set; }

    public Notification? Notification { get; set; }

    public List<Notification>? Notifications { get; set; }

    public bool? Read { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
