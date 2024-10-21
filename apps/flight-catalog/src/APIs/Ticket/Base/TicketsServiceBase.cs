using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using FlightCatalog.APIs.Extensions;
using FlightCatalog.Infrastructure;
using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.APIs;

public abstract class TicketsServiceBase : ITicketsService
{
    protected readonly FlightCatalogDbContext _context;

    public TicketsServiceBase(FlightCatalogDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Ticket
    /// </summary>
    public async Task<Ticket> CreateTicket(TicketCreateInput createDto)
    {
        var ticket = new TicketDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Price = createDto.Price,
            SeatNumber = createDto.SeatNumber,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            ticket.Id = createDto.Id;
        }
        if (createDto.Flight != null)
        {
            ticket.Flight = await _context
                .Flights.Where(flight => createDto.Flight.Id == flight.Id)
                .FirstOrDefaultAsync();
        }

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TicketDbModel>(ticket.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Ticket
    /// </summary>
    public async Task DeleteTicket(TicketWhereUniqueInput uniqueId)
    {
        var ticket = await _context.Tickets.FindAsync(uniqueId.Id);
        if (ticket == null)
        {
            throw new NotFoundException();
        }

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Tickets
    /// </summary>
    public async Task<List<Ticket>> Tickets(TicketFindManyArgs findManyArgs)
    {
        var tickets = await _context
            .Tickets.Include(x => x.Flight)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return tickets.ConvertAll(ticket => ticket.ToDto());
    }

    /// <summary>
    /// Meta data about Ticket records
    /// </summary>
    public async Task<MetadataDto> TicketsMeta(TicketFindManyArgs findManyArgs)
    {
        var count = await _context.Tickets.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Ticket
    /// </summary>
    public async Task<Ticket> Ticket(TicketWhereUniqueInput uniqueId)
    {
        var tickets = await this.Tickets(
            new TicketFindManyArgs { Where = new TicketWhereInput { Id = uniqueId.Id } }
        );
        var ticket = tickets.FirstOrDefault();
        if (ticket == null)
        {
            throw new NotFoundException();
        }

        return ticket;
    }

    /// <summary>
    /// Update one Ticket
    /// </summary>
    public async Task UpdateTicket(TicketWhereUniqueInput uniqueId, TicketUpdateInput updateDto)
    {
        var ticket = updateDto.ToModel(uniqueId);

        if (updateDto.Flight != null)
        {
            ticket.Flight = await _context
                .Flights.Where(flight => updateDto.Flight == flight.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(ticket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tickets.Any(e => e.Id == ticket.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a Flight record for Ticket
    /// </summary>
    public async Task<Flight> GetFlight(TicketWhereUniqueInput uniqueId)
    {
        var ticket = await _context
            .Tickets.Where(ticket => ticket.Id == uniqueId.Id)
            .Include(ticket => ticket.Flight)
            .FirstOrDefaultAsync();
        if (ticket == null)
        {
            throw new NotFoundException();
        }
        return ticket.Flight.ToDto();
    }
}
