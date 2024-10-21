using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using FlightCatalog.APIs.Extensions;
using FlightCatalog.Infrastructure;
using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.APIs;

public abstract class AirlinesServiceBase : IAirlinesService
{
    protected readonly FlightCatalogDbContext _context;

    public AirlinesServiceBase(FlightCatalogDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Airline
    /// </summary>
    public async Task<Airline> CreateAirline(AirlineCreateInput createDto)
    {
        var airline = new AirlineDbModel
        {
            Country = createDto.Country,
            CreatedAt = createDto.CreatedAt,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            airline.Id = createDto.Id;
        }
        if (createDto.Flights != null)
        {
            airline.Flights = await _context
                .Flights.Where(flight => createDto.Flights.Select(t => t.Id).Contains(flight.Id))
                .ToListAsync();
        }

        _context.Airlines.Add(airline);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AirlineDbModel>(airline.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Airline
    /// </summary>
    public async Task DeleteAirline(AirlineWhereUniqueInput uniqueId)
    {
        var airline = await _context.Airlines.FindAsync(uniqueId.Id);
        if (airline == null)
        {
            throw new NotFoundException();
        }

        _context.Airlines.Remove(airline);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Airlines
    /// </summary>
    public async Task<List<Airline>> Airlines(AirlineFindManyArgs findManyArgs)
    {
        var airlines = await _context
            .Airlines.Include(x => x.Flights)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return airlines.ConvertAll(airline => airline.ToDto());
    }

    /// <summary>
    /// Meta data about Airline records
    /// </summary>
    public async Task<MetadataDto> AirlinesMeta(AirlineFindManyArgs findManyArgs)
    {
        var count = await _context.Airlines.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Airline
    /// </summary>
    public async Task<Airline> Airline(AirlineWhereUniqueInput uniqueId)
    {
        var airlines = await this.Airlines(
            new AirlineFindManyArgs { Where = new AirlineWhereInput { Id = uniqueId.Id } }
        );
        var airline = airlines.FirstOrDefault();
        if (airline == null)
        {
            throw new NotFoundException();
        }

        return airline;
    }

    /// <summary>
    /// Update one Airline
    /// </summary>
    public async Task UpdateAirline(AirlineWhereUniqueInput uniqueId, AirlineUpdateInput updateDto)
    {
        var airline = updateDto.ToModel(uniqueId);

        if (updateDto.Flights != null)
        {
            airline.Flights = await _context
                .Flights.Where(flight => updateDto.Flights.Select(t => t).Contains(flight.Id))
                .ToListAsync();
        }

        _context.Entry(airline).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Airlines.Any(e => e.Id == airline.Id))
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
    /// Connect multiple Flights records to Airline
    /// </summary>
    public async Task ConnectFlights(
        AirlineWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Airlines.Include(x => x.Flights)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Flights.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Flights);

        foreach (var child in childrenToConnect)
        {
            parent.Flights.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Flights records from Airline
    /// </summary>
    public async Task DisconnectFlights(
        AirlineWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Airlines.Include(x => x.Flights)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Flights.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Flights?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Flights records for Airline
    /// </summary>
    public async Task<List<Flight>> FindFlights(
        AirlineWhereUniqueInput uniqueId,
        FlightFindManyArgs airlineFindManyArgs
    )
    {
        var flights = await _context
            .Flights.Where(m => m.AirlineId == uniqueId.Id)
            .ApplyWhere(airlineFindManyArgs.Where)
            .ApplySkip(airlineFindManyArgs.Skip)
            .ApplyTake(airlineFindManyArgs.Take)
            .ApplyOrderBy(airlineFindManyArgs.SortBy)
            .ToListAsync();

        return flights.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Flights records for Airline
    /// </summary>
    public async Task UpdateFlights(
        AirlineWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] childrenIds
    )
    {
        var airline = await _context
            .Airlines.Include(t => t.Flights)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (airline == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Flights.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        airline.Flights = children;
        await _context.SaveChangesAsync();
    }
}
