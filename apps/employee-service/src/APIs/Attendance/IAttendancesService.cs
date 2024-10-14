using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;

namespace EmployeeService.APIs;

public interface IAttendancesService
{
    /// <summary>
    /// Create one Attendance
    /// </summary>
    public Task<Attendance> CreateAttendance(AttendanceCreateInput attendance);

    /// <summary>
    /// Delete one Attendance
    /// </summary>
    public Task DeleteAttendance(AttendanceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Attendances
    /// </summary>
    public Task<List<Attendance>> Attendances(AttendanceFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Attendance records
    /// </summary>
    public Task<MetadataDto> AttendancesMeta(AttendanceFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Attendance
    /// </summary>
    public Task<Attendance> Attendance(AttendanceWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Attendance
    /// </summary>
    public Task UpdateAttendance(
        AttendanceWhereUniqueInput uniqueId,
        AttendanceUpdateInput updateDto
    );

    /// <summary>
    /// Get a Employee record for Attendance
    /// </summary>
    public Task<Employee> GetEmployee(AttendanceWhereUniqueInput uniqueId);
}
