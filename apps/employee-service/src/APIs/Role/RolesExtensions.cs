using EmployeeService.APIs.Dtos;
using EmployeeService.Infrastructure.Models;

namespace EmployeeService.APIs.Extensions;

public static class RolesExtensions
{
    public static Role ToDto(this RoleDbModel model)
    {
        return new Role
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            ProjectAssignments = model.ProjectAssignments?.Select(x => x.Id).ToList(),
            SalaryRange = model.SalaryRange,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RoleDbModel ToModel(this RoleUpdateInput updateDto, RoleWhereUniqueInput uniqueId)
    {
        var role = new RoleDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Name = updateDto.Name,
            SalaryRange = updateDto.SalaryRange
        };

        if (updateDto.CreatedAt != null)
        {
            role.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            role.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return role;
    }
}
