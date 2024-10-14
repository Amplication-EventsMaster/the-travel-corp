namespace EmployeeService.APIs.Dtos;

public class ProjectAssignmentCreateInput
{
    public DateTime CreatedAt { get; set; }

    public Employee? Employee { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Id { get; set; }

    public string? ProjectName { get; set; }

    public Role? Role { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime UpdatedAt { get; set; }
}
