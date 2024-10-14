namespace EmployeeService.APIs.Dtos;

public class Attendance
{
    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? Employee { get; set; }

    public string Id { get; set; }

    public string? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
