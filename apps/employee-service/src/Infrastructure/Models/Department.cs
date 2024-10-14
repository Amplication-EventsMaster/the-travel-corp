using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Infrastructure.Models;

[Table("Departments")]
public class DepartmentDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<EmployeeDbModel>? Employees { get; set; } = new List<EmployeeDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Location { get; set; }

    [StringLength(1000)]
    public string? Manager { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
