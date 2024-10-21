using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightCatalog.Infrastructure.Models;

[Table("Airlines")]
public class AirlineDbModel
{
    [StringLength(1000)]
    public string? Country { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<FlightDbModel>? Flights { get; set; } = new List<FlightDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
