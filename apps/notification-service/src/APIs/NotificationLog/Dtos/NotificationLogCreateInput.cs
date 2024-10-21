namespace NotificationService.APIs.Dtos;

public class NotificationLogCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public Notification? Notification { get; set; }

    public string? Status { get; set; }

    public DateTime? Timestamp { get; set; }

    public DateTime UpdatedAt { get; set; }
}
