using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using FlightCatalog.APIs.Extensions;
using FlightCatalog.Infrastructure;
using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.APIs;

public abstract class FlightsServiceBase : IFlightsService
{
    protected readonly FlightCatalogDbContext _context;

    public FlightsServiceBase(FlightCatalogDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Flight
    /// </summary>
    public async Task<Flight> CreateFlight(FlightCreateInput createDto)
    {
        var flight = new FlightDbModel
        {
            ArrivalTime = createDto.ArrivalTime,
            CreatedAt = createDto.CreatedAt,
            DepartureTime = createDto.DepartureTime,
            FlightNumber = createDto.FlightNumber,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            flight.Id = createDto.Id;
        }
        if (createDto.Airline != null)
        {
            flight.Airline = await _context
                .Airlines.Where(airline => createDto.Airline.Id == airline.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Route != null)
        {
            flight.Route = await _context
                .Routes.Where(route => createDto.Route.Id == route.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Schedules != null)
        {
            flight.Schedules = await _context
                .Schedules.Where(schedule =>
                    createDto.Schedules.Select(t => t.Id).Contains(schedule.Id)
                )
                .ToListAsync();
        }

        if (createDto.Tickets != null)
        {
            flight.Tickets = await _context
                .Tickets.Where(ticket => createDto.Tickets.Select(t => t.Id).Contains(ticket.Id))
                .ToListAsync();
        }

        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FlightDbModel>(flight.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Flight
    /// </summary>
    public async Task DeleteFlight(FlightWhereUniqueInput uniqueId)
    {
        var flight = await _context.Flights.FindAsync(uniqueId.Id);
        if (flight == null)
        {
            throw new NotFoundException();
        }

        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Flights
    /// </summary>
    public async Task<List<Flight>> Flights(FlightFindManyArgs findManyArgs)
    {
        var flights = await _context
            .Flights.Include(x => x.Airline)
            .Include(x => x.Route)
            .Include(x => x.Tickets)
            .Include(x => x.Schedules)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return flights.ConvertAll(flight => flight.ToDto());
    }

    /// <summary>
    /// Meta data about Flight records
    /// </summary>
    public async Task<MetadataDto> FlightsMeta(FlightFindManyArgs findManyArgs)
    {
        var count = await _context.Flights.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Flight
    /// </summary>
    public async Task<Flight> Flight(FlightWhereUniqueInput uniqueId)
    {
        var flights = await this.Flights(
            new FlightFindManyArgs { Where = new FlightWhereInput { Id = uniqueId.Id } }
        );
        var flight = flights.FirstOrDefault();
        if (flight == null)
        {
            throw new NotFoundException();
        }

        return flight;
    }

    /// <summary>
    /// Update one Flight
    /// </summary>
    public async Task UpdateFlight(FlightWhereUniqueInput uniqueId, FlightUpdateInput updateDto)
    {
        var flight = updateDto.ToModel(uniqueId);

        if (updateDto.Airline != null)
        {
            flight.Airline = await _context
                .Airlines.Where(airline => updateDto.Airline == airline.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Route != null)
        {
            flight.Route = await _context
                .Routes.Where(route => updateDto.Route == route.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Schedules != null)
        {
            flight.Schedules = await _context
                .Schedules.Where(schedule =>
                    updateDto.Schedules.Select(t => t).Contains(schedule.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Tickets != null)
        {
            flight.Tickets = await _context
                .Tickets.Where(ticket => updateDto.Tickets.Select(t => t).Contains(ticket.Id))
                .ToListAsync();
        }

        _context.Entry(flight).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Flights.Any(e => e.Id == flight.Id))
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
    /// Get a Airline record for Flight
    /// </summary>
    public async Task<Airline> GetAirline(FlightWhereUniqueInput uniqueId)
    {
        var flight = await _context
            .Flights.Where(flight => flight.Id == uniqueId.Id)
            .Include(flight => flight.Airline)
            .FirstOrDefaultAsync();
        if (flight == null)
        {
            throw new NotFoundException();
        }
        return flight.Airline.ToDto();
    }

    /// <summary>
    /// Get a Route record for Flight
    /// </summary>
    public async Task<Route> GetRoute(FlightWhereUniqueInput uniqueId)
    {
        var flight = await _context
            .Flights.Where(flight => flight.Id == uniqueId.Id)
            .Include(flight => flight.Route)
            .FirstOrDefaultAsync();
        if (flight == null)
        {
            throw new NotFoundException();
        }
        return flight.Route.ToDto();
    }

    /// <summary>
    /// Connect multiple Schedules records to Flight
    /// </summary>
    public async Task ConnectSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Flights.Include(x => x.Schedules)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Schedules.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Schedules);

        foreach (var child in childrenToConnect)
        {
            parent.Schedules.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Schedules records from Flight
    /// </summary>
    public async Task DisconnectSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Flights.Include(x => x.Schedules)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Schedules.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Schedules?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Schedules records for Flight
    /// </summary>
    public async Task<List<Schedule>> FindSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleFindManyArgs flightFindManyArgs
    )
    {
        var schedules = await _context
            .Schedules.Where(m => m.FlightId == uniqueId.Id)
            .ApplyWhere(flightFindManyArgs.Where)
            .ApplySkip(flightFindManyArgs.Skip)
            .ApplyTake(flightFindManyArgs.Take)
            .ApplyOrderBy(flightFindManyArgs.SortBy)
            .ToListAsync();

        return schedules.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Schedules records for Flight
    /// </summary>
    public async Task UpdateSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] childrenIds
    )
    {
        var flight = await _context
            .Flights.Include(t => t.Schedules)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (flight == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Schedules.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        flight.Schedules = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Tickets records to Flight
    /// </summary>
    public async Task ConnectTickets(
        FlightWhereUniqueInput uniqueId,
        TicketWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Flights.Include(x => x.Tickets)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Tickets.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Tickets);

        foreach (var child in childrenToConnect)
        {
            parent.Tickets.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Tickets records from Flight
    /// </summary>
    public async Task DisconnectTickets(
        FlightWhereUniqueInput uniqueId,
        TicketWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Flights.Include(x => x.Tickets)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Tickets.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Tickets?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Tickets records for Flight
    /// </summary>
    public async Task<List<Ticket>> FindTickets(
        FlightWhereUniqueInput uniqueId,
        TicketFindManyArgs flightFindManyArgs
    )
    {
        var tickets = await _context
            .Tickets.Where(m => m.FlightId == uniqueId.Id)
            .ApplyWhere(flightFindManyArgs.Where)
            .ApplySkip(flightFindManyArgs.Skip)
            .ApplyTake(flightFindManyArgs.Take)
            .ApplyOrderBy(flightFindManyArgs.SortBy)
            .ToListAsync();

        return tickets.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Tickets records for Flight
    /// </summary>
    public async Task UpdateTickets(
        FlightWhereUniqueInput uniqueId,
        TicketWhereUniqueInput[] childrenIds
    )
    {
        var flight = await _context
            .Flights.Include(t => t.Tickets)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (flight == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Tickets.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        flight.Tickets = children;
        await _context.SaveChangesAsync();
    }
}
