namespace NotificationService.APIs.Dtos;

public class NotificationLog
{
    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? Notification { get; set; }

    public string? Status { get; set; }

    public DateTime? Timestamp { get; set; }

    public DateTime UpdatedAt { get; set; }
}
