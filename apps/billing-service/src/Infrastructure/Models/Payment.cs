using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Infrastructure.Models;

[Table("Payments")]
public class PaymentDbModel
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? InvoiceId { get; set; }

    [ForeignKey(nameof(InvoiceId))]
    public InvoiceDbModel? Invoice { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
