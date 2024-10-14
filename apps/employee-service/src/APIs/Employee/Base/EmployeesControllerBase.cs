using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmployeesControllerBase : ControllerBase
{
    protected readonly IEmployeesService _service;

    public EmployeesControllerBase(IEmployeesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Employee
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateInput input)
    {
        var employee = await _service.CreateEmployee(input);

        return CreatedAtAction(nameof(Employee), new { id = employee.Id }, employee);
    }

    /// <summary>
    /// Delete one Employee
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmployee([FromRoute()] EmployeeWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteEmployee(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Employees
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Employee>>> Employees(
        [FromQuery()] EmployeeFindManyArgs filter
    )
    {
        return Ok(await _service.Employees(filter));
    }

    /// <summary>
    /// Meta data about Employee records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmployeesMeta(
        [FromQuery()] EmployeeFindManyArgs filter
    )
    {
        return Ok(await _service.EmployeesMeta(filter));
    }

    /// <summary>
    /// Get one Employee
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Employee>> Employee(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Employee(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Employee
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmployee(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
        [FromQuery()] EmployeeUpdateInput employeeUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmployee(uniqueId, employeeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Attendances records to Employee
    /// </summary>
    [HttpPost("{Id}/attendances")]
    public async Task<ActionResult> ConnectAttendances(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
        [FromQuery()] AttendanceWhereUniqueInput[] attendancesId
    )
    {
        try
        {
            await _service.ConnectAttendances(uniqueId, attendancesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Attendances records from Employee
    /// </summary>
    [HttpDelete("{Id}/attendances")]
    public async Task<ActionResult> DisconnectAttendances(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
        [FromBody()] AttendanceWhereUniqueInput[] attendancesId
    )
    {
        try
        {
            await _service.DisconnectAttendances(uniqueId, attendancesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Attendances records for Employee
    /// </summary>
    [HttpGet("{Id}/attendances")]
    public async Task<ActionResult<List<Attendance>>> FindAttendances(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
        [FromQuery()] AttendanceFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAttendances(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Attendances records for Employee
    /// </summary>
    [HttpPatch("{Id}/attendances")]
    public async Task<ActionResult> UpdateAttendances(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
        [FromBody()] AttendanceWhereUniqueInput[] attendancesId
    )
    {
        try
        {
            await _service.UpdateAttendances(uniqueId, attendancesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Department record for Employee
    /// </summary>
    [HttpGet("{Id}/department")]
    public async Task<ActionResult<List<Department>>> GetDepartment(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId
    )
    {
        var department = await _service.GetDepartment(uniqueId);
        return Ok(department);
    }

    /// <summary>
    /// Connect multiple ProjectAssignments records to Employee
    /// </summary>
    [HttpPost("{Id}/projectAssignments")]
    public async Task<ActionResult> ConnectProjectAssignments(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
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
    /// Disconnect multiple ProjectAssignments records from Employee
    /// </summary>
    [HttpDelete("{Id}/projectAssignments")]
    public async Task<ActionResult> DisconnectProjectAssignments(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
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
    /// Find multiple ProjectAssignments records for Employee
    /// </summary>
    [HttpGet("{Id}/projectAssignments")]
    public async Task<ActionResult<List<ProjectAssignment>>> FindProjectAssignments(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
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
    /// Update multiple ProjectAssignments records for Employee
    /// </summary>
    [HttpPatch("{Id}/projectAssignments")]
    public async Task<ActionResult> UpdateProjectAssignments(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
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
