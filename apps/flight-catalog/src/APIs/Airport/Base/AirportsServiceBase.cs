using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using FlightCatalog.APIs.Extensions;
using FlightCatalog.Infrastructure;
using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.APIs;

public abstract class AirportsServiceBase : IAirportsService
{
    protected readonly FlightCatalogDbContext _context;

    public AirportsServiceBase(FlightCatalogDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Airport
    /// </summary>
    public async Task<Airport> CreateAirport(AirportCreateInput createDto)
    {
        var airport = new AirportDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Location = createDto.Location,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            airport.Id = createDto.Id;
        }
        if (createDto.Schedules != null)
        {
            airport.Schedules = await _context
                .Schedules.Where(schedule =>
                    createDto.Schedules.Select(t => t.Id).Contains(schedule.Id)
                )
                .ToListAsync();
        }

        _context.Airports.Add(airport);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AirportDbModel>(airport.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Airport
    /// </summary>
    public async Task DeleteAirport(AirportWhereUniqueInput uniqueId)
    {
        var airport = await _context.Airports.FindAsync(uniqueId.Id);
        if (airport == null)
        {
            throw new NotFoundException();
        }

        _context.Airports.Remove(airport);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Airports
    /// </summary>
    public async Task<List<Airport>> Airports(AirportFindManyArgs findManyArgs)
    {
        var airports = await _context
            .Airports.Include(x => x.Schedules)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return airports.ConvertAll(airport => airport.ToDto());
    }

    /// <summary>
    /// Meta data about Airport records
    /// </summary>
    public async Task<MetadataDto> AirportsMeta(AirportFindManyArgs findManyArgs)
    {
        var count = await _context.Airports.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Airport
    /// </summary>
    public async Task<Airport> Airport(AirportWhereUniqueInput uniqueId)
    {
        var airports = await this.Airports(
            new AirportFindManyArgs { Where = new AirportWhereInput { Id = uniqueId.Id } }
        );
        var airport = airports.FirstOrDefault();
        if (airport == null)
        {
            throw new NotFoundException();
        }

        return airport;
    }

    /// <summary>
    /// Update one Airport
    /// </summary>
    public async Task UpdateAirport(AirportWhereUniqueInput uniqueId, AirportUpdateInput updateDto)
    {
        var airport = updateDto.ToModel(uniqueId);

        if (updateDto.Schedules != null)
        {
            airport.Schedules = await _context
                .Schedules.Where(schedule =>
                    updateDto.Schedules.Select(t => t).Contains(schedule.Id)
                )
                .ToListAsync();
        }

        _context.Entry(airport).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Airports.Any(e => e.Id == airport.Id))
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
    /// Connect multiple Schedules records to Airport
    /// </summary>
    public async Task ConnectSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Airports.Include(x => x.Schedules)
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
    /// Disconnect multiple Schedules records from Airport
    /// </summary>
    public async Task DisconnectSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Airports.Include(x => x.Schedules)
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
    /// Find multiple Schedules records for Airport
    /// </summary>
    public async Task<List<Schedule>> FindSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleFindManyArgs airportFindManyArgs
    )
    {
        var schedules = await _context
            .Schedules.Where(m => m.AirportId == uniqueId.Id)
            .ApplyWhere(airportFindManyArgs.Where)
            .ApplySkip(airportFindManyArgs.Skip)
            .ApplyTake(airportFindManyArgs.Take)
            .ApplyOrderBy(airportFindManyArgs.SortBy)
            .ToListAsync();

        return schedules.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Schedules records for Airport
    /// </summary>
    public async Task UpdateSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] childrenIds
    )
    {
        var airport = await _context
            .Airports.Include(t => t.Schedules)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (airport == null)
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

        airport.Schedules = children;
        await _context.SaveChangesAsync();
    }
}
