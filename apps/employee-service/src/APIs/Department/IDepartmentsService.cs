using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;

namespace EmployeeService.APIs;

public interface IDepartmentsService
{
    /// <summary>
    /// Create one Department
    /// </summary>
    public Task<Department> CreateDepartment(DepartmentCreateInput department);

    /// <summary>
    /// Delete one Department
    /// </summary>
    public Task DeleteDepartment(DepartmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Departments
    /// </summary>
    public Task<List<Department>> Departments(DepartmentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Department records
    /// </summary>
    public Task<MetadataDto> DepartmentsMeta(DepartmentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Department
    /// </summary>
    public Task<Department> Department(DepartmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Department
    /// </summary>
    public Task UpdateDepartment(
        DepartmentWhereUniqueInput uniqueId,
        DepartmentUpdateInput updateDto
    );

    /// <summary>
    /// Connect multiple Employees records to Department
    /// </summary>
    public Task ConnectEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeWhereUniqueInput[] employeesId
    );

    /// <summary>
    /// Disconnect multiple Employees records from Department
    /// </summary>
    public Task DisconnectEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeWhereUniqueInput[] employeesId
    );

    /// <summary>
    /// Find multiple Employees records for Department
    /// </summary>
    public Task<List<Employee>> FindEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeFindManyArgs EmployeeFindManyArgs
    );

    /// <summary>
    /// Update multiple Employees records for Department
    /// </summary>
    public Task UpdateEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeWhereUniqueInput[] employeesId
    );
}
