using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationService.Infrastructure.Models;

[Table("NotificationLogs")]
public class NotificationLogDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? NotificationId { get; set; }

    [ForeignKey(nameof(NotificationId))]
    public NotificationDbModel? Notification { get; set; } = null;

    [StringLength(1000)]
    public string? Status { get; set; }

    public DateTime? Timestamp { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
