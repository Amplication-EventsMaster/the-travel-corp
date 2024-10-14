using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;

namespace EmployeeService.APIs;

public interface IRolesService
{
    /// <summary>
    /// Create one Role
    /// </summary>
    public Task<Role> CreateRole(RoleCreateInput role);

    /// <summary>
    /// Delete one Role
    /// </summary>
    public Task DeleteRole(RoleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Roles
    /// </summary>
    public Task<List<Role>> Roles(RoleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Role records
    /// </summary>
    public Task<MetadataDto> RolesMeta(RoleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Role
    /// </summary>
    public Task<Role> Role(RoleWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Role
    /// </summary>
    public Task UpdateRole(RoleWhereUniqueInput uniqueId, RoleUpdateInput updateDto);

    /// <summary>
    /// Connect multiple ProjectAssignments records to Role
    /// </summary>
    public Task ConnectProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    );

    /// <summary>
    /// Disconnect multiple ProjectAssignments records from Role
    /// </summary>
    public Task DisconnectProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    );

    /// <summary>
    /// Find multiple ProjectAssignments records for Role
    /// </summary>
    public Task<List<ProjectAssignment>> FindProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentFindManyArgs ProjectAssignmentFindManyArgs
    );

    /// <summary>
    /// Update multiple ProjectAssignments records for Role
    /// </summary>
    public Task UpdateProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    );
}
