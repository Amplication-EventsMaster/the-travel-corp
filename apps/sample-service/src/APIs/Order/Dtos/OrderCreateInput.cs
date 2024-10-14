namespace SampleService.APIs.Dtos;

public class OrderCreateInput
{
    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public List<Feedback>? Feedbacks { get; set; }

    public string? Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public List<Payment>? Payments { get; set; }

    public string? Status { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime UpdatedAt { get; set; }
}
