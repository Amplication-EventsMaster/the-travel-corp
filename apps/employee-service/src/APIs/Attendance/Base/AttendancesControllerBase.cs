using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AttendancesControllerBase : ControllerBase
{
    protected readonly IAttendancesService _service;

    public AttendancesControllerBase(IAttendancesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Attendance
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Attendance>> CreateAttendance(AttendanceCreateInput input)
    {
        var attendance = await _service.CreateAttendance(input);

        return CreatedAtAction(nameof(Attendance), new { id = attendance.Id }, attendance);
    }

    /// <summary>
    /// Delete one Attendance
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAttendance(
        [FromRoute()] AttendanceWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAttendance(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Attendances
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Attendance>>> Attendances(
        [FromQuery()] AttendanceFindManyArgs filter
    )
    {
        return Ok(await _service.Attendances(filter));
    }

    /// <summary>
    /// Meta data about Attendance records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AttendancesMeta(
        [FromQuery()] AttendanceFindManyArgs filter
    )
    {
        return Ok(await _service.AttendancesMeta(filter));
    }

    /// <summary>
    /// Get one Attendance
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Attendance>> Attendance(
        [FromRoute()] AttendanceWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Attendance(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Attendance
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAttendance(
        [FromRoute()] AttendanceWhereUniqueInput uniqueId,
        [FromQuery()] AttendanceUpdateInput attendanceUpdateDto
    )
    {
        try
        {
            await _service.UpdateAttendance(uniqueId, attendanceUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Employee record for Attendance
    /// </summary>
    [HttpGet("{Id}/employee")]
    public async Task<ActionResult<List<Employee>>> GetEmployee(
        [FromRoute()] AttendanceWhereUniqueInput uniqueId
    )
    {
        var employee = await _service.GetEmployee(uniqueId);
        return Ok(employee);
    }
}
