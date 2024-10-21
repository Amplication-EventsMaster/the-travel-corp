using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightCatalog.Infrastructure.Models;

[Table("Flights")]
public class FlightDbModel
{
    public string? AirlineId { get; set; }

    [ForeignKey(nameof(AirlineId))]
    public AirlineDbModel? Airline { get; set; } = null;

    public DateTime? ArrivalTime { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? DepartureTime { get; set; }

    [StringLength(1000)]
    public string? FlightNumber { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? RouteId { get; set; }

    [ForeignKey(nameof(RouteId))]
    public RouteDbModel? Route { get; set; } = null;

    public List<ScheduleDbModel>? Schedules { get; set; } = new List<ScheduleDbModel>();

    public List<TicketDbModel>? Tickets { get; set; } = new List<TicketDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
