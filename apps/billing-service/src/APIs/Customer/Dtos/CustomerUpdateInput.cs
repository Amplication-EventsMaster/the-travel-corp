namespace BillingService.APIs.Dtos;

public class CustomerUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public List<string>? Invoices { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
