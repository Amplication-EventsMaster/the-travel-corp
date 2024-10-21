namespace FlightCatalog.APIs.Dtos;

public class Schedule
{
    public string? Airport { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Day { get; set; }

    public string? Flight { get; set; }

    public string Id { get; set; }

    public DateTime? Time { get; set; }

    public DateTime UpdatedAt { get; set; }
}
