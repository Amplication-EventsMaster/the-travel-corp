using EmployeeService.APIs.Dtos;
using EmployeeService.Infrastructure.Models;

namespace EmployeeService.APIs.Extensions;

public static class EmployeesExtensions
{
    public static Employee ToDto(this EmployeeDbModel model)
    {
        return new Employee
        {
            Attendances = model.Attendances?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            DateOfBirth = model.DateOfBirth,
            Department = model.DepartmentId,
            Email = model.Email,
            Id = model.Id,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber,
            Position = model.Position,
            ProjectAssignments = model.ProjectAssignments?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmployeeDbModel ToModel(
        this EmployeeUpdateInput updateDto,
        EmployeeWhereUniqueInput uniqueId
    )
    {
        var employee = new EmployeeDbModel
        {
            Id = uniqueId.Id,
            DateOfBirth = updateDto.DateOfBirth,
            Email = updateDto.Email,
            Name = updateDto.Name,
            PhoneNumber = updateDto.PhoneNumber,
            Position = updateDto.Position
        };

        if (updateDto.CreatedAt != null)
        {
            employee.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Department != null)
        {
            employee.DepartmentId = updateDto.Department;
        }
        if (updateDto.UpdatedAt != null)
        {
            employee.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return employee;
    }
}
