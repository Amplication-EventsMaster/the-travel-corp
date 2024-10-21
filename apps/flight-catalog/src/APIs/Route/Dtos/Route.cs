namespace FlightCatalog.APIs.Dtos;

public class Route
{
    public DateTime CreatedAt { get; set; }

    public string? Destination { get; set; }

    public List<string>? Flights { get; set; }

    public string Id { get; set; }

    public string? Origin { get; set; }

    public DateTime UpdatedAt { get; set; }
}
