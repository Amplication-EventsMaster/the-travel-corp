using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AirlinesControllerBase : ControllerBase
{
    protected readonly IAirlinesService _service;

    public AirlinesControllerBase(IAirlinesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Airline
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Airline>> CreateAirline(AirlineCreateInput input)
    {
        var airline = await _service.CreateAirline(input);

        return CreatedAtAction(nameof(Airline), new { id = airline.Id }, airline);
    }

    /// <summary>
    /// Delete one Airline
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAirline([FromRoute()] AirlineWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAirline(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Airlines
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Airline>>> Airlines(
        [FromQuery()] AirlineFindManyArgs filter
    )
    {
        return Ok(await _service.Airlines(filter));
    }

    /// <summary>
    /// Meta data about Airline records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AirlinesMeta(
        [FromQuery()] AirlineFindManyArgs filter
    )
    {
        return Ok(await _service.AirlinesMeta(filter));
    }

    /// <summary>
    /// Get one Airline
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Airline>> Airline([FromRoute()] AirlineWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Airline(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Airline
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAirline(
        [FromRoute()] AirlineWhereUniqueInput uniqueId,
        [FromQuery()] AirlineUpdateInput airlineUpdateDto
    )
    {
        try
        {
            await _service.UpdateAirline(uniqueId, airlineUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Flights records to Airline
    /// </summary>
    [HttpPost("{Id}/flights")]
    public async Task<ActionResult> ConnectFlights(
        [FromRoute()] AirlineWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Flights records from Airline
    /// </summary>
    [HttpDelete("{Id}/flights")]
    public async Task<ActionResult> DisconnectFlights(
        [FromRoute()] AirlineWhereUniqueInput uniqueId,
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
    /// Find multiple Flights records for Airline
    /// </summary>
    [HttpGet("{Id}/flights")]
    public async Task<ActionResult<List<Flight>>> FindFlights(
        [FromRoute()] AirlineWhereUniqueInput uniqueId,
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
    /// Update multiple Flights records for Airline
    /// </summary>
    [HttpPatch("{Id}/flights")]
    public async Task<ActionResult> UpdateFlights(
        [FromRoute()] AirlineWhereUniqueInput uniqueId,
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
