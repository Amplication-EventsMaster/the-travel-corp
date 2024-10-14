using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Infrastructure.Models;

[Table("Attendances")]
public class AttendanceDbModel
{
    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public EmployeeDbModel? Employee { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
