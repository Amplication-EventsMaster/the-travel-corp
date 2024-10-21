using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightCatalog.Infrastructure.Models;

[Table("Routes")]
public class RouteDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Destination { get; set; }

    public List<FlightDbModel>? Flights { get; set; } = new List<FlightDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Origin { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
