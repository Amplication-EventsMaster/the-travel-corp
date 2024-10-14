namespace EmployeeService.APIs.Dtos;

public class Employee
{
    public List<string>? Attendances { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Department { get; set; }

    public string? Email { get; set; }

    public string Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Position { get; set; }

    public List<string>? ProjectAssignments { get; set; }

    public DateTime UpdatedAt { get; set; }
}
