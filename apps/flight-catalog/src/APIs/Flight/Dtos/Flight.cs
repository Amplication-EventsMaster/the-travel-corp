namespace FlightCatalog.APIs.Dtos;

public class Flight
{
    public string? Airline { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DepartureTime { get; set; }

    public string? FlightNumber { get; set; }

    public string Id { get; set; }

    public string? Route { get; set; }

    public List<string>? Schedules { get; set; }

    public List<string>? Tickets { get; set; }

    public DateTime UpdatedAt { get; set; }
}
