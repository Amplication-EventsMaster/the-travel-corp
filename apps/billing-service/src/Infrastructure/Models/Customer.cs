using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Infrastructure.Models;

[Table("Customers")]
public class CustomerDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<InvoiceDbModel>? Invoices { get; set; } = new List<InvoiceDbModel>();

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
