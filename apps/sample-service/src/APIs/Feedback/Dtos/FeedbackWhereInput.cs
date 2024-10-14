namespace SampleService.APIs.Dtos;

public class FeedbackWhereInput
{
    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Order { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
