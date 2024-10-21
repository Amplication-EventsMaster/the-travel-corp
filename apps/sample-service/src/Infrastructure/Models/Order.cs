using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleService.Infrastructure.Models;

[Table("Orders")]
public class OrderDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerDbModel? Customer { get; set; } = null;

    public List<FeedbackDbModel>? Feedbacks { get; set; } = new List<FeedbackDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public List<PaymentDbModel>? Payments { get; set; } = new List<PaymentDbModel>();

    [StringLength(1000)]
    public string? Status { get; set; }

    [Range(-999999999, 999999999)]
    public double? TotalAmount { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
