namespace FlightCatalog.APIs.Dtos;

public class RouteCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Destination { get; set; }

    public List<Flight>? Flights { get; set; }

    public string? Id { get; set; }

    public string? Origin { get; set; }

    public DateTime UpdatedAt { get; set; }
}
