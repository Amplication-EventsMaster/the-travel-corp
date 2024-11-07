namespace TrackingService_2.APIs.Dtos;

public class TrackingCreateInput
{
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
