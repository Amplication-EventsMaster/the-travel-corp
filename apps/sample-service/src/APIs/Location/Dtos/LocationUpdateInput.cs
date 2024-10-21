namespace SampleService.APIs.Dtos;

public class LocationUpdateInput
{
    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
