namespace BillingService.APIs.Dtos;

public class PaymentCreateInput
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? Id { get; set; }

    public Invoice? Invoice { get; set; }

    public DateTime UpdatedAt { get; set; }
}
