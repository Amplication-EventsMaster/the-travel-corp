using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AirportsControllerBase : ControllerBase
{
    protected readonly IAirportsService _service;

    public AirportsControllerBase(IAirportsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Airport
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Airport>> CreateAirport(AirportCreateInput input)
    {
        var airport = await _service.CreateAirport(input);

        return CreatedAtAction(nameof(Airport), new { id = airport.Id }, airport);
    }

    /// <summary>
    /// Delete one Airport
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAirport([FromRoute()] AirportWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAirport(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Airports
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Airport>>> Airports(
        [FromQuery()] AirportFindManyArgs filter
    )
    {
        return Ok(await _service.Airports(filter));
    }

    /// <summary>
    /// Meta data about Airport records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AirportsMeta(
        [FromQuery()] AirportFindManyArgs filter
    )
    {
        return Ok(await _service.AirportsMeta(filter));
    }

    /// <summary>
    /// Get one Airport
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Airport>> Airport([FromRoute()] AirportWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Airport(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Airport
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAirport(
        [FromRoute()] AirportWhereUniqueInput uniqueId,
        [FromQuery()] AirportUpdateInput airportUpdateDto
    )
    {
        try
        {
            await _service.UpdateAirport(uniqueId, airportUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Schedules records to Airport
    /// </summary>
    [HttpPost("{Id}/schedules")]
    public async Task<ActionResult> ConnectSchedules(
        [FromRoute()] AirportWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.ConnectSchedules(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Schedules records from Airport
    /// </summary>
    [HttpDelete("{Id}/schedules")]
    public async Task<ActionResult> DisconnectSchedules(
        [FromRoute()] AirportWhereUniqueInput uniqueId,
        [FromBody()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.DisconnectSchedules(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Schedules records for Airport
    /// </summary>
    [HttpGet("{Id}/schedules")]
    public async Task<ActionResult<List<Schedule>>> FindSchedules(
        [FromRoute()] AirportWhereUniqueInput uniqueId,
        [FromQuery()] ScheduleFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSchedules(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Schedules records for Airport
    /// </summary>
    [HttpPatch("{Id}/schedules")]
    public async Task<ActionResult> UpdateSchedules(
        [FromRoute()] AirportWhereUniqueInput uniqueId,
        [FromBody()] ScheduleWhereUniqueInput[] schedulesId
    )
    {
        try
        {
            await _service.UpdateSchedules(uniqueId, schedulesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
