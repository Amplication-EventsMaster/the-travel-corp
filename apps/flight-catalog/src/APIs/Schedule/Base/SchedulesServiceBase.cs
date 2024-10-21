using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using FlightCatalog.APIs.Extensions;
using FlightCatalog.Infrastructure;
using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.APIs;

public abstract class SchedulesServiceBase : ISchedulesService
{
    protected readonly FlightCatalogDbContext _context;

    public SchedulesServiceBase(FlightCatalogDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Schedule
    /// </summary>
    public async Task<Schedule> CreateSchedule(ScheduleCreateInput createDto)
    {
        var schedule = new ScheduleDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Day = createDto.Day,
            Time = createDto.Time,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            schedule.Id = createDto.Id;
        }
        if (createDto.Airport != null)
        {
            schedule.Airport = await _context
                .Airports.Where(airport => createDto.Airport.Id == airport.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Flight != null)
        {
            schedule.Flight = await _context
                .Flights.Where(flight => createDto.Flight.Id == flight.Id)
                .FirstOrDefaultAsync();
        }

        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ScheduleDbModel>(schedule.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Schedule
    /// </summary>
    public async Task DeleteSchedule(ScheduleWhereUniqueInput uniqueId)
    {
        var schedule = await _context.Schedules.FindAsync(uniqueId.Id);
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Schedules
    /// </summary>
    public async Task<List<Schedule>> Schedules(ScheduleFindManyArgs findManyArgs)
    {
        var schedules = await _context
            .Schedules.Include(x => x.Flight)
            .Include(x => x.Airport)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return schedules.ConvertAll(schedule => schedule.ToDto());
    }

    /// <summary>
    /// Meta data about Schedule records
    /// </summary>
    public async Task<MetadataDto> SchedulesMeta(ScheduleFindManyArgs findManyArgs)
    {
        var count = await _context.Schedules.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Schedule
    /// </summary>
    public async Task<Schedule> Schedule(ScheduleWhereUniqueInput uniqueId)
    {
        var schedules = await this.Schedules(
            new ScheduleFindManyArgs { Where = new ScheduleWhereInput { Id = uniqueId.Id } }
        );
        var schedule = schedules.FirstOrDefault();
        if (schedule == null)
        {
            throw new NotFoundException();
        }

        return schedule;
    }

    /// <summary>
    /// Update one Schedule
    /// </summary>
    public async Task UpdateSchedule(
        ScheduleWhereUniqueInput uniqueId,
        ScheduleUpdateInput updateDto
    )
    {
        var schedule = updateDto.ToModel(uniqueId);

        if (updateDto.Airport != null)
        {
            schedule.Airport = await _context
                .Airports.Where(airport => updateDto.Airport == airport.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Flight != null)
        {
            schedule.Flight = await _context
                .Flights.Where(flight => updateDto.Flight == flight.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(schedule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Schedules.Any(e => e.Id == schedule.Id))
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
    /// Get a Airport record for Schedule
    /// </summary>
    public async Task<Airport> GetAirport(ScheduleWhereUniqueInput uniqueId)
    {
        var schedule = await _context
            .Schedules.Where(schedule => schedule.Id == uniqueId.Id)
            .Include(schedule => schedule.Airport)
            .FirstOrDefaultAsync();
        if (schedule == null)
        {
            throw new NotFoundException();
        }
        return schedule.Airport.ToDto();
    }

    /// <summary>
    /// Get a Flight record for Schedule
    /// </summary>
    public async Task<Flight> GetFlight(ScheduleWhereUniqueInput uniqueId)
    {
        var schedule = await _context
            .Schedules.Where(schedule => schedule.Id == uniqueId.Id)
            .Include(schedule => schedule.Flight)
            .FirstOrDefaultAsync();
        if (schedule == null)
        {
            throw new NotFoundException();
        }
        return schedule.Flight.ToDto();
    }
}
