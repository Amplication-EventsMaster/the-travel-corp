namespace EmployeeService.APIs.Dtos;

public class EmployeeCreateInput
{
    public List<Attendance>? Attendances { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Department? Department { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Position { get; set; }

    public List<ProjectAssignment>? ProjectAssignments { get; set; }

    public DateTime UpdatedAt { get; set; }
}
