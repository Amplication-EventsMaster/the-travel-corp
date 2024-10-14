using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Infrastructure.Models;

[Table("Employees")]
public class EmployeeDbModel
{
    public List<AttendanceDbModel>? Attendances { get; set; } = new List<AttendanceDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public DepartmentDbModel? Department { get; set; } = null;

    public string? Email { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? PhoneNumber { get; set; }

    [StringLength(1000)]
    public string? Position { get; set; }

    public List<ProjectAssignmentDbModel>? ProjectAssignments { get; set; } =
        new List<ProjectAssignmentDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
