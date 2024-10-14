using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;

namespace EmployeeService.APIs;

public interface IEmployeesService
{
    /// <summary>
    /// Create one Employee
    /// </summary>
    public Task<Employee> CreateEmployee(EmployeeCreateInput employee);

    /// <summary>
    /// Delete one Employee
    /// </summary>
    public Task DeleteEmployee(EmployeeWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Employees
    /// </summary>
    public Task<List<Employee>> Employees(EmployeeFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Employee records
    /// </summary>
    public Task<MetadataDto> EmployeesMeta(EmployeeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Employee
    /// </summary>
    public Task<Employee> Employee(EmployeeWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Employee
    /// </summary>
    public Task UpdateEmployee(EmployeeWhereUniqueInput uniqueId, EmployeeUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Attendances records to Employee
    /// </summary>
    public Task ConnectAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceWhereUniqueInput[] attendancesId
    );

    /// <summary>
    /// Disconnect multiple Attendances records from Employee
    /// </summary>
    public Task DisconnectAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceWhereUniqueInput[] attendancesId
    );

    /// <summary>
    /// Find multiple Attendances records for Employee
    /// </summary>
    public Task<List<Attendance>> FindAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceFindManyArgs AttendanceFindManyArgs
    );

    /// <summary>
    /// Update multiple Attendances records for Employee
    /// </summary>
    public Task UpdateAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceWhereUniqueInput[] attendancesId
    );

    /// <summary>
    /// Get a Department record for Employee
    /// </summary>
    public Task<Department> GetDepartment(EmployeeWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple ProjectAssignments records to Employee
    /// </summary>
    public Task ConnectProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    );

    /// <summary>
    /// Disconnect multiple ProjectAssignments records from Employee
    /// </summary>
    public Task DisconnectProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    );

    /// <summary>
    /// Find multiple ProjectAssignments records for Employee
    /// </summary>
    public Task<List<ProjectAssignment>> FindProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentFindManyArgs ProjectAssignmentFindManyArgs
    );

    /// <summary>
    /// Update multiple ProjectAssignments records for Employee
    /// </summary>
    public Task UpdateProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    );
}
