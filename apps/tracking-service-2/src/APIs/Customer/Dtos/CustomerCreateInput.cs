namespace TrackingService_2.APIs.Dtos;

public class CustomerCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<Tracking>? Trackings { get; set; }

    public DateTime UpdatedAt { get; set; }
}
