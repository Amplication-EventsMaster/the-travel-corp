namespace FlightCatalog.APIs.Dtos;

public class AirlineUpdateInput
{
    public string? Country { get; set; }

    public DateTime? CreatedAt { get; set; }

    public List<string>? Flights { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
