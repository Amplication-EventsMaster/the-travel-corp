namespace FlightCatalog.APIs.Dtos;

public class FlightCreateInput
{
    public Airline? Airline { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DepartureTime { get; set; }

    public string? FlightNumber { get; set; }

    public string? Id { get; set; }

    public Route? Route { get; set; }

    public List<Schedule>? Schedules { get; set; }

    public List<Ticket>? Tickets { get; set; }

    public DateTime UpdatedAt { get; set; }
}
