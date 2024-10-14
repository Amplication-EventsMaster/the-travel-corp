namespace SampleService.APIs.Dtos;

public class Order
{
    public DateTime CreatedAt { get; set; }

    public string? Customer { get; set; }

    public List<string>? Feedbacks { get; set; }

    public string Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public List<string>? Payments { get; set; }

    public string? Status { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime UpdatedAt { get; set; }
}
