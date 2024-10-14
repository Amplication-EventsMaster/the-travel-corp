namespace EmployeeService.APIs.Dtos;

public class RoleWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<string>? ProjectAssignments { get; set; }

    public string? SalaryRange { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
