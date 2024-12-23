namespace EmployeeService.APIs.Dtos;

public class DepartmentCreateInput
{
    public DateTime CreatedAt { get; set; }

    public List<Employee>? Employees { get; set; }

    public string? Id { get; set; }

    public string? Location { get; set; }

    public string? Manager { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
