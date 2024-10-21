namespace FlightCatalog.APIs.Dtos;

public class TicketUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Flight { get; set; }

    public string? Id { get; set; }

    public double? Price { get; set; }

    public string? SeatNumber { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
