using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DepartmentsControllerBase : ControllerBase
{
    protected readonly IDepartmentsService _service;

    public DepartmentsControllerBase(IDepartmentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Department
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Department>> CreateDepartment(DepartmentCreateInput input)
    {
        var department = await _service.CreateDepartment(input);

        return CreatedAtAction(nameof(Department), new { id = department.Id }, department);
    }

    /// <summary>
    /// Delete one Department
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDepartment(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteDepartment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Departments
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Department>>> Departments(
        [FromQuery()] DepartmentFindManyArgs filter
    )
    {
        return Ok(await _service.Departments(filter));
    }

    /// <summary>
    /// Meta data about Department records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DepartmentsMeta(
        [FromQuery()] DepartmentFindManyArgs filter
    )
    {
        return Ok(await _service.DepartmentsMeta(filter));
    }

    /// <summary>
    /// Get one Department
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Department>> Department(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Department(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Department
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDepartment(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId,
        [FromQuery()] DepartmentUpdateInput departmentUpdateDto
    )
    {
        try
        {
            await _service.UpdateDepartment(uniqueId, departmentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Employees records to Department
    /// </summary>
    [HttpPost("{Id}/employees")]
    public async Task<ActionResult> ConnectEmployees(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId,
        [FromQuery()] EmployeeWhereUniqueInput[] employeesId
    )
    {
        try
        {
            await _service.ConnectEmployees(uniqueId, employeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Employees records from Department
    /// </summary>
    [HttpDelete("{Id}/employees")]
    public async Task<ActionResult> DisconnectEmployees(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId,
        [FromBody()] EmployeeWhereUniqueInput[] employeesId
    )
    {
        try
        {
            await _service.DisconnectEmployees(uniqueId, employeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Employees records for Department
    /// </summary>
    [HttpGet("{Id}/employees")]
    public async Task<ActionResult<List<Employee>>> FindEmployees(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId,
        [FromQuery()] EmployeeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEmployees(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Employees records for Department
    /// </summary>
    [HttpPatch("{Id}/employees")]
    public async Task<ActionResult> UpdateEmployees(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId,
        [FromBody()] EmployeeWhereUniqueInput[] employeesId
    )
    {
        try
        {
            await _service.UpdateEmployees(uniqueId, employeesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
