namespace EmployeeService.APIs.Dtos;

public class AttendanceCreateInput
{
    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public Employee? Employee { get; set; }

    public string? Id { get; set; }

    public string? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
