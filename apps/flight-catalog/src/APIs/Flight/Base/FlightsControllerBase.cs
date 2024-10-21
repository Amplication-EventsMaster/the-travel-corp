using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FlightsControllerBase : ControllerBase
{
    protected readonly IFlightsService _service;

    public FlightsControllerBase(IFlightsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Flight
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Flight>> CreateFlight(FlightCreateInput input)
    {
        var flight = await _service.CreateFlight(input);

        return CreatedAtAction(nameof(Flight), new { id = flight.Id }, flight);
    }

    /// <summary>
    /// Delete one Flight
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFlight([FromRoute()] FlightWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFlight(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Flights
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Flight>>> Flights([FromQuery()] FlightFindManyArgs filter)
    {
        return Ok(await _service.Flights(filter));
    }

    /// <summary>
    /// Meta data about Flight records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FlightsMeta(
        [FromQuery()] FlightFindManyArgs filter
    )
    {
        return Ok(await _service.FlightsMeta(filter));
    }

    /// <summary>
    /// Get one Flight
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Flight>> Flight([FromRoute()] FlightWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Flight(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Flight
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFlight(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
        [FromQuery()] FlightUpdateInput flightUpdateDto
    )
    {
        try
        {
            await _service.UpdateFlight(uniqueId, flightUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Airline record for Flight
    /// </summary>
    [HttpGet("{Id}/airline")]
    public async Task<ActionResult<List<Airline>>> GetAirline(
        [FromRoute()] FlightWhereUniqueInput uniqueId
    )
    {
        var airline = await _service.GetAirline(uniqueId);
        return Ok(airline);
    }

    /// <summary>
    /// Get a Route record for Flight
    /// </summary>
    [HttpGet("{Id}/route")]
    public async Task<ActionResult<List<Route>>> GetRoute(
        [FromRoute()] FlightWhereUniqueInput uniqueId
    )
    {
        var route = await _service.GetRoute(uniqueId);
        return Ok(route);
    }

    /// <summary>
    /// Connect multiple Schedules records to Flight
    /// </summary>
    [HttpPost("{Id}/schedules")]
    public async Task<ActionResult> ConnectSchedules(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Schedules records from Flight
    /// </summary>
    [HttpDelete("{Id}/schedules")]
    public async Task<ActionResult> DisconnectSchedules(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
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
    /// Find multiple Schedules records for Flight
    /// </summary>
    [HttpGet("{Id}/schedules")]
    public async Task<ActionResult<List<Schedule>>> FindSchedules(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
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
    /// Update multiple Schedules records for Flight
    /// </summary>
    [HttpPatch("{Id}/schedules")]
    public async Task<ActionResult> UpdateSchedules(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
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

    /// <summary>
    /// Connect multiple Tickets records to Flight
    /// </summary>
    [HttpPost("{Id}/tickets")]
    public async Task<ActionResult> ConnectTickets(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
        [FromQuery()] TicketWhereUniqueInput[] ticketsId
    )
    {
        try
        {
            await _service.ConnectTickets(uniqueId, ticketsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Tickets records from Flight
    /// </summary>
    [HttpDelete("{Id}/tickets")]
    public async Task<ActionResult> DisconnectTickets(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
        [FromBody()] TicketWhereUniqueInput[] ticketsId
    )
    {
        try
        {
            await _service.DisconnectTickets(uniqueId, ticketsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Tickets records for Flight
    /// </summary>
    [HttpGet("{Id}/tickets")]
    public async Task<ActionResult<List<Ticket>>> FindTickets(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
        [FromQuery()] TicketFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindTickets(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Tickets records for Flight
    /// </summary>
    [HttpPatch("{Id}/tickets")]
    public async Task<ActionResult> UpdateTickets(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
        [FromBody()] TicketWhereUniqueInput[] ticketsId
    )
    {
        try
        {
            await _service.UpdateTickets(uniqueId, ticketsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
