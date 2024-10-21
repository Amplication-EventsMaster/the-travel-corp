namespace FlightCatalog.APIs.Dtos;

public class AirportWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }

    public List<string>? Schedules { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
