using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightCatalog.Infrastructure.Models;

[Table("Schedules")]
public class ScheduleDbModel
{
    public string? AirportId { get; set; }

    [ForeignKey(nameof(AirportId))]
    public AirportDbModel? Airport { get; set; } = null;

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Day { get; set; }

    public string? FlightId { get; set; }

    [ForeignKey(nameof(FlightId))]
    public FlightDbModel? Flight { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? Time { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
