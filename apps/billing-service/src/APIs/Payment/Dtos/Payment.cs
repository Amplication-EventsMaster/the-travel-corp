namespace BillingService.APIs.Dtos;

public class Payment
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string Id { get; set; }

    public string? Invoice { get; set; }

    public DateTime UpdatedAt { get; set; }
}
