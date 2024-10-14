using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Infrastructure.Models;

[Table("Roles")]
public class RoleDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public List<ProjectAssignmentDbModel>? ProjectAssignments { get; set; } =
        new List<ProjectAssignmentDbModel>();

    [StringLength(1000)]
    public string? SalaryRange { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
