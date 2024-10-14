namespace SampleService.APIs.Dtos;

public class FeedbackCreateInput
{
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public Order? Order { get; set; }

    public DateTime UpdatedAt { get; set; }
}
