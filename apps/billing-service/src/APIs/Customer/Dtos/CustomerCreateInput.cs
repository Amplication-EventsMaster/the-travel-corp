namespace BillingService.APIs.Dtos;

public class CustomerCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public List<Invoice>? Invoices { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public DateTime UpdatedAt { get; set; }
}
