namespace BillingService.APIs.Dtos;

public class InvoiceCreateInput
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public DateTime? Date { get; set; }

    public string? Id { get; set; }

    public List<Payment>? Payments { get; set; }

    public DateTime UpdatedAt { get; set; }
}
