namespace BillingService.APIs.Dtos;

public class Feedback
{
    public string? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Customer { get; set; }

    public string Id { get; set; }

    public int? Rating { get; set; }

    public DateTime UpdatedAt { get; set; }
}
