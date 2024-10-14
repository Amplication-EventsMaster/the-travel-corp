using EmployeeService.APIs.Dtos;
using EmployeeService.Infrastructure.Models;

namespace EmployeeService.APIs.Extensions;

public static class ProjectAssignmentsExtensions
{
    public static ProjectAssignment ToDto(this ProjectAssignmentDbModel model)
    {
        return new ProjectAssignment
        {
            CreatedAt = model.CreatedAt,
            Employee = model.EmployeeId,
            EndDate = model.EndDate,
            Id = model.Id,
            ProjectName = model.ProjectName,
            Role = model.RoleId,
            StartDate = model.StartDate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ProjectAssignmentDbModel ToModel(
        this ProjectAssignmentUpdateInput updateDto,
        ProjectAssignmentWhereUniqueInput uniqueId
    )
    {
        var projectAssignment = new ProjectAssignmentDbModel
        {
            Id = uniqueId.Id,
            EndDate = updateDto.EndDate,
            ProjectName = updateDto.ProjectName,
            StartDate = updateDto.StartDate
        };

        if (updateDto.CreatedAt != null)
        {
            projectAssignment.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Employee != null)
        {
            projectAssignment.EmployeeId = updateDto.Employee;
        }
        if (updateDto.Role != null)
        {
            projectAssignment.RoleId = updateDto.Role;
        }
        if (updateDto.UpdatedAt != null)
        {
            projectAssignment.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return projectAssignment;
    }
}
