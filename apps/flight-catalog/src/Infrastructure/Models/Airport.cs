using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightCatalog.Infrastructure.Models;

[Table("Airports")]
public class AirportDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Location { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public List<ScheduleDbModel>? Schedules { get; set; } = new List<ScheduleDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
