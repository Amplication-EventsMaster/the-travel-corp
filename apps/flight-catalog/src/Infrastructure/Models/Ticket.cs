using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightCatalog.Infrastructure.Models;

[Table("Tickets")]
public class TicketDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? FlightId { get; set; }

    [ForeignKey(nameof(FlightId))]
    public FlightDbModel? Flight { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    [StringLength(1000)]
    public string? SeatNumber { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
