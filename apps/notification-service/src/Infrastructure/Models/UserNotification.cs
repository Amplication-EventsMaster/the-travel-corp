using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationService.Infrastructure.Models;

[Table("UserNotifications")]
public class UserNotificationDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Message { get; set; }

    public string? NotificationId { get; set; }

    [ForeignKey(nameof(NotificationId))]
    public NotificationDbModel? Notification { get; set; } = null;

    public List<NotificationDbModel>? Notifications { get; set; } = new List<NotificationDbModel>();

    public bool? Read { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? User { get; set; }
}
