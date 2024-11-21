namespace TrackingService_2.APIs.Dtos;

public class CustomerUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<string>? Trackings { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
