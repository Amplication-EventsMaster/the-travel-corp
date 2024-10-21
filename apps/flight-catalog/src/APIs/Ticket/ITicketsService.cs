using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;

namespace FlightCatalog.APIs;

public interface ITicketsService
{
    /// <summary>
    /// Create one Ticket
    /// </summary>
    public Task<Ticket> CreateTicket(TicketCreateInput ticket);

    /// <summary>
    /// Delete one Ticket
    /// </summary>
    public Task DeleteTicket(TicketWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Tickets
    /// </summary>
    public Task<List<Ticket>> Tickets(TicketFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Ticket records
    /// </summary>
    public Task<MetadataDto> TicketsMeta(TicketFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Ticket
    /// </summary>
    public Task<Ticket> Ticket(TicketWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Ticket
    /// </summary>
    public Task UpdateTicket(TicketWhereUniqueInput uniqueId, TicketUpdateInput updateDto);

    /// <summary>
    /// Get a Flight record for Ticket
    /// </summary>
    public Task<Flight> GetFlight(TicketWhereUniqueInput uniqueId);
}
