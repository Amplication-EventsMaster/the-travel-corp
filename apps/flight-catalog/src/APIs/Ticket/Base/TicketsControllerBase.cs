using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TicketsControllerBase : ControllerBase
{
    protected readonly ITicketsService _service;

    public TicketsControllerBase(ITicketsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Ticket
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Ticket>> CreateTicket(TicketCreateInput input)
    {
        var ticket = await _service.CreateTicket(input);

        return CreatedAtAction(nameof(Ticket), new { id = ticket.Id }, ticket);
    }

    /// <summary>
    /// Delete one Ticket
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTicket([FromRoute()] TicketWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTicket(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Tickets
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Ticket>>> Tickets([FromQuery()] TicketFindManyArgs filter)
    {
        return Ok(await _service.Tickets(filter));
    }

    /// <summary>
    /// Meta data about Ticket records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TicketsMeta(
        [FromQuery()] TicketFindManyArgs filter
    )
    {
        return Ok(await _service.TicketsMeta(filter));
    }

    /// <summary>
    /// Get one Ticket
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Ticket>> Ticket([FromRoute()] TicketWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Ticket(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Ticket
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTicket(
        [FromRoute()] TicketWhereUniqueInput uniqueId,
        [FromQuery()] TicketUpdateInput ticketUpdateDto
    )
    {
        try
        {
            await _service.UpdateTicket(uniqueId, ticketUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Flight record for Ticket
    /// </summary>
    [HttpGet("{Id}/flight")]
    public async Task<ActionResult<List<Flight>>> GetFlight(
        [FromRoute()] TicketWhereUniqueInput uniqueId
    )
    {
        var flight = await _service.GetFlight(uniqueId);
        return Ok(flight);
    }
}
