namespace EmployeeService.APIs.Dtos;

public class ProjectAssignmentWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Employee { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Id { get; set; }

    public string? ProjectName { get; set; }

    public string? Role { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
