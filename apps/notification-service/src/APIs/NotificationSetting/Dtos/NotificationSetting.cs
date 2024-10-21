using NotificationService.Core.Enums;

namespace NotificationService.APIs.Dtos;

public class NotificationSetting
{
    public DateTime CreatedAt { get; set; }

    public FrequencyEnum? Frequency { get; set; }

    public string Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
