using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RolesControllerBase : ControllerBase
{
    protected readonly IRolesService _service;

    public RolesControllerBase(IRolesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Role
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Role>> CreateRole(RoleCreateInput input)
    {
        var role = await _service.CreateRole(input);

        return CreatedAtAction(nameof(Role), new { id = role.Id }, role);
    }

    /// <summary>
    /// Delete one Role
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRole([FromRoute()] RoleWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRole(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Roles
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Role>>> Roles([FromQuery()] RoleFindManyArgs filter)
    {
        return Ok(await _service.Roles(filter));
    }

    /// <summary>
    /// Meta data about Role records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RolesMeta([FromQuery()] RoleFindManyArgs filter)
    {
        return Ok(await _service.RolesMeta(filter));
    }

    /// <summary>
    /// Get one Role
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Role>> Role([FromRoute()] RoleWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Role(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Role
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateRole(
        [FromRoute()] RoleWhereUniqueInput uniqueId,
        [FromQuery()] RoleUpdateInput roleUpdateDto
    )
    {
        try
        {
            await _service.UpdateRole(uniqueId, roleUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple ProjectAssignments records to Role
    /// </summary>
    [HttpPost("{Id}/projectAssignments")]
    public async Task<ActionResult> ConnectProjectAssignments(
        [FromRoute()] RoleWhereUniqueInput uniqueId,
        [FromQuery()] ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    )
    {
        try
        {
            await _service.ConnectProjectAssignments(uniqueId, projectAssignmentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple ProjectAssignments records from Role
    /// </summary>
    [HttpDelete("{Id}/projectAssignments")]
    public async Task<ActionResult> DisconnectProjectAssignments(
        [FromRoute()] RoleWhereUniqueInput uniqueId,
        [FromBody()] ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    )
    {
        try
        {
            await _service.DisconnectProjectAssignments(uniqueId, projectAssignmentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple ProjectAssignments records for Role
    /// </summary>
    [HttpGet("{Id}/projectAssignments")]
    public async Task<ActionResult<List<ProjectAssignment>>> FindProjectAssignments(
        [FromRoute()] RoleWhereUniqueInput uniqueId,
        [FromQuery()] ProjectAssignmentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindProjectAssignments(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple ProjectAssignments records for Role
    /// </summary>
    [HttpPatch("{Id}/projectAssignments")]
    public async Task<ActionResult> UpdateProjectAssignments(
        [FromRoute()] RoleWhereUniqueInput uniqueId,
        [FromBody()] ProjectAssignmentWhereUniqueInput[] projectAssignmentsId
    )
    {
        try
        {
            await _service.UpdateProjectAssignments(uniqueId, projectAssignmentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
