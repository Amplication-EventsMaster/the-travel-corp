using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationService.Core.Enums;

namespace NotificationService.Infrastructure.Models;

[Table("NotificationSettings")]
public class NotificationSettingDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public FrequencyEnum? Frequency { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? User { get; set; }
}
