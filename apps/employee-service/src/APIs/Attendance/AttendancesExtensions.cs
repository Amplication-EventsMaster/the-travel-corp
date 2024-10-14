using EmployeeService.APIs.Dtos;
using EmployeeService.Infrastructure.Models;

namespace EmployeeService.APIs.Extensions;

public static class AttendancesExtensions
{
    public static Attendance ToDto(this AttendanceDbModel model)
    {
        return new Attendance
        {
            CheckInTime = model.CheckInTime,
            CheckOutTime = model.CheckOutTime,
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            Employee = model.EmployeeId,
            Id = model.Id,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AttendanceDbModel ToModel(
        this AttendanceUpdateInput updateDto,
        AttendanceWhereUniqueInput uniqueId
    )
    {
        var attendance = new AttendanceDbModel
        {
            Id = uniqueId.Id,
            CheckInTime = updateDto.CheckInTime,
            CheckOutTime = updateDto.CheckOutTime,
            Date = updateDto.Date,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            attendance.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Employee != null)
        {
            attendance.EmployeeId = updateDto.Employee;
        }
        if (updateDto.UpdatedAt != null)
        {
            attendance.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return attendance;
    }
}
