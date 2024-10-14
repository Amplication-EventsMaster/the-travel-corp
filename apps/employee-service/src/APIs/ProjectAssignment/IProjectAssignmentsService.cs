using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;

namespace EmployeeService.APIs;

public interface IProjectAssignmentsService
{
    /// <summary>
    /// Create one ProjectAssignment
    /// </summary>
    public Task<ProjectAssignment> CreateProjectAssignment(
        ProjectAssignmentCreateInput projectassignment
    );

    /// <summary>
    /// Delete one ProjectAssignment
    /// </summary>
    public Task DeleteProjectAssignment(ProjectAssignmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ProjectAssignments
    /// </summary>
    public Task<List<ProjectAssignment>> ProjectAssignments(
        ProjectAssignmentFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about ProjectAssignment records
    /// </summary>
    public Task<MetadataDto> ProjectAssignmentsMeta(ProjectAssignmentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ProjectAssignment
    /// </summary>
    public Task<ProjectAssignment> ProjectAssignment(ProjectAssignmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ProjectAssignment
    /// </summary>
    public Task UpdateProjectAssignment(
        ProjectAssignmentWhereUniqueInput uniqueId,
        ProjectAssignmentUpdateInput updateDto
    );

    /// <summary>
    /// Get a Employee record for ProjectAssignment
    /// </summary>
    public Task<Employee> GetEmployee(ProjectAssignmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Role record for ProjectAssignment
    /// </summary>
    public Task<Role> GetRole(ProjectAssignmentWhereUniqueInput uniqueId);
}
