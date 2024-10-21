namespace FlightCatalog.APIs.Dtos;

public class TicketCreateInput
{
    public DateTime CreatedAt { get; set; }

    public Flight? Flight { get; set; }

    public string? Id { get; set; }

    public double? Price { get; set; }

    public string? SeatNumber { get; set; }

    public DateTime UpdatedAt { get; set; }
}
