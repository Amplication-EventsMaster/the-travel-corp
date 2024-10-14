using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProjectAssignmentsControllerBase : ControllerBase
{
    protected readonly IProjectAssignmentsService _service;

    public ProjectAssignmentsControllerBase(IProjectAssignmentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ProjectAssignment
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ProjectAssignment>> CreateProjectAssignment(
        ProjectAssignmentCreateInput input
    )
    {
        var projectAssignment = await _service.CreateProjectAssignment(input);

        return CreatedAtAction(
            nameof(ProjectAssignment),
            new { id = projectAssignment.Id },
            projectAssignment
        );
    }

    /// <summary>
    /// Delete one ProjectAssignment
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteProjectAssignment(
        [FromRoute()] ProjectAssignmentWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteProjectAssignment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ProjectAssignments
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ProjectAssignment>>> ProjectAssignments(
        [FromQuery()] ProjectAssignmentFindManyArgs filter
    )
    {
        return Ok(await _service.ProjectAssignments(filter));
    }

    /// <summary>
    /// Meta data about ProjectAssignment records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ProjectAssignmentsMeta(
        [FromQuery()] ProjectAssignmentFindManyArgs filter
    )
    {
        return Ok(await _service.ProjectAssignmentsMeta(filter));
    }

    /// <summary>
    /// Get one ProjectAssignment
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ProjectAssignment>> ProjectAssignment(
        [FromRoute()] ProjectAssignmentWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ProjectAssignment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ProjectAssignment
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateProjectAssignment(
        [FromRoute()] ProjectAssignmentWhereUniqueInput uniqueId,
        [FromQuery()] ProjectAssignmentUpdateInput projectAssignmentUpdateDto
    )
    {
        try
        {
            await _service.UpdateProjectAssignment(uniqueId, projectAssignmentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Employee record for ProjectAssignment
    /// </summary>
    [HttpGet("{Id}/employee")]
    public async Task<ActionResult<List<Employee>>> GetEmployee(
        [FromRoute()] ProjectAssignmentWhereUniqueInput uniqueId
    )
    {
        var employee = await _service.GetEmployee(uniqueId);
        return Ok(employee);
    }

    /// <summary>
    /// Get a Role record for ProjectAssignment
    /// </summary>
    [HttpGet("{Id}/role")]
    public async Task<ActionResult<List<Role>>> GetRole(
        [FromRoute()] ProjectAssignmentWhereUniqueInput uniqueId
    )
    {
        var role = await _service.GetRole(uniqueId);
        return Ok(role);
    }
}
