using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;

namespace FlightCatalog.APIs;

public interface ISchedulesService
{
    /// <summary>
    /// Create one Schedule
    /// </summary>
    public Task<Schedule> CreateSchedule(ScheduleCreateInput schedule);

    /// <summary>
    /// Delete one Schedule
    /// </summary>
    public Task DeleteSchedule(ScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Schedules
    /// </summary>
    public Task<List<Schedule>> Schedules(ScheduleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Schedule records
    /// </summary>
    public Task<MetadataDto> SchedulesMeta(ScheduleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Schedule
    /// </summary>
    public Task<Schedule> Schedule(ScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Schedule
    /// </summary>
    public Task UpdateSchedule(ScheduleWhereUniqueInput uniqueId, ScheduleUpdateInput updateDto);

    /// <summary>
    /// Get a Airport record for Schedule
    /// </summary>
    public Task<Airport> GetAirport(ScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Flight record for Schedule
    /// </summary>
    public Task<Flight> GetFlight(ScheduleWhereUniqueInput uniqueId);
}
