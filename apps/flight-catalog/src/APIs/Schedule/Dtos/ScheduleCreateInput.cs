namespace FlightCatalog.APIs.Dtos;

public class ScheduleCreateInput
{
    public Airport? Airport { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Day { get; set; }

    public Flight? Flight { get; set; }

    public string? Id { get; set; }

    public DateTime? Time { get; set; }

    public DateTime UpdatedAt { get; set; }
}
