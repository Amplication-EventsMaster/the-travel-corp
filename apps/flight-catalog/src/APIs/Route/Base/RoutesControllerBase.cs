using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RoutesControllerBase : ControllerBase
{
    protected readonly IRoutesService _service;

    public RoutesControllerBase(IRoutesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Route
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Route>> CreateRoute(RouteCreateInput input)
    {
        var route = await _service.CreateRoute(input);

        return CreatedAtAction(nameof(Route), new { id = route.Id }, route);
    }

    /// <summary>
    /// Delete one Route
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRoute([FromRoute()] RouteWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRoute(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Routes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Route>>> Routes([FromQuery()] RouteFindManyArgs filter)
    {
        return Ok(await _service.Routes(filter));
    }

    /// <summary>
    /// Meta data about Route records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RoutesMeta([FromQuery()] RouteFindManyArgs filter)
    {
        return Ok(await _service.RoutesMeta(filter));
    }

    /// <summary>
    /// Get one Route
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Route>> Route([FromRoute()] RouteWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Route(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Route
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateRoute(
        [FromRoute()] RouteWhereUniqueInput uniqueId,
        [FromQuery()] RouteUpdateInput routeUpdateDto
    )
    {
        try
        {
            await _service.UpdateRoute(uniqueId, routeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Flights records to Route
    /// </summary>
    [HttpPost("{Id}/flights")]
    public async Task<ActionResult> ConnectFlights(
        [FromRoute()] RouteWhereUniqueInput uniqueId,
        [FromQuery()] FlightWhereUniqueInput[] flightsId
    )
    {
        try
        {
            await _service.ConnectFlights(uniqueId, flightsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Flights records from Route
    /// </summary>
    [HttpDelete("{Id}/flights")]
    public async Task<ActionResult> DisconnectFlights(
        [FromRoute()] RouteWhereUniqueInput uniqueId,
        [FromBody()] FlightWhereUniqueInput[] flightsId
    )
    {
        try
        {
            await _service.DisconnectFlights(uniqueId, flightsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Flights records for Route
    /// </summary>
    [HttpGet("{Id}/flights")]
    public async Task<ActionResult<List<Flight>>> FindFlights(
        [FromRoute()] RouteWhereUniqueInput uniqueId,
        [FromQuery()] FlightFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFlights(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Flights records for Route
    /// </summary>
    [HttpPatch("{Id}/flights")]
    public async Task<ActionResult> UpdateFlights(
        [FromRoute()] RouteWhereUniqueInput uniqueId,
        [FromBody()] FlightWhereUniqueInput[] flightsId
    )
    {
        try
        {
            await _service.UpdateFlights(uniqueId, flightsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
