using EmployeeService.APIs.Dtos;
using EmployeeService.Infrastructure.Models;

namespace EmployeeService.APIs.Extensions;

public static class DepartmentsExtensions
{
    public static Department ToDto(this DepartmentDbModel model)
    {
        return new Department
        {
            CreatedAt = model.CreatedAt,
            Employees = model.Employees?.Select(x => x.Id).ToList(),
            Id = model.Id,
            Location = model.Location,
            Manager = model.Manager,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static DepartmentDbModel ToModel(
        this DepartmentUpdateInput updateDto,
        DepartmentWhereUniqueInput uniqueId
    )
    {
        var department = new DepartmentDbModel
        {
            Id = uniqueId.Id,
            Location = updateDto.Location,
            Manager = updateDto.Manager,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            department.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            department.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return department;
    }
}
