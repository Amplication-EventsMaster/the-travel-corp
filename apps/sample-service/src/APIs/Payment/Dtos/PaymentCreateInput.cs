namespace SampleService.APIs.Dtos;

public class PaymentCreateInput
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Method { get; set; }

    public Order? Order { get; set; }

    public DateTime? PaymentDate { get; set; }

    public DateTime UpdatedAt { get; set; }
}
