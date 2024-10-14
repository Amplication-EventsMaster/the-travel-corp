using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Infrastructure.Models;

[Table("ProjectAssignments")]
public class ProjectAssignmentDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public EmployeeDbModel? Employee { get; set; } = null;

    public DateTime? EndDate { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? ProjectName { get; set; }

    public string? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public RoleDbModel? Role { get; set; } = null;

    public DateTime? StartDate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
