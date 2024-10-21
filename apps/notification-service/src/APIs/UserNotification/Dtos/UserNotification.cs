namespace NotificationService.APIs.Dtos;

public class UserNotification
{
    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? Message { get; set; }

    public string? Notification { get; set; }

    public List<string>? Notifications { get; set; }

    public bool? Read { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
