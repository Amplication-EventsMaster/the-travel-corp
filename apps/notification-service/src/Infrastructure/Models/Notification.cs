using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationService.Infrastructure.Models;

[Table("Notifications")]
public class NotificationDbModel
{
    [StringLength(1000)]
    public string? Content { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<NotificationLogDbModel>? NotificationLogs { get; set; } =
        new List<NotificationLogDbModel>();

    public string? NotificationTypeId { get; set; }

    [ForeignKey(nameof(NotificationTypeId))]
    public NotificationTypeDbModel? NotificationType { get; set; } = null;

    [StringLength(1000)]
    public string? Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserNotificationId { get; set; }

    [ForeignKey(nameof(UserNotificationId))]
    public UserNotificationDbModel? UserNotification { get; set; } = null;

    public List<UserNotificationDbModel>? UserNotifications { get; set; } =
        new List<UserNotificationDbModel>();
}
