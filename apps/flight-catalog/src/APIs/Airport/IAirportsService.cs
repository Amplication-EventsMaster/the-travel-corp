using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;

namespace FlightCatalog.APIs;

public interface IAirportsService
{
    /// <summary>
    /// Create one Airport
    /// </summary>
    public Task<Airport> CreateAirport(AirportCreateInput airport);

    /// <summary>
    /// Delete one Airport
    /// </summary>
    public Task DeleteAirport(AirportWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Airports
    /// </summary>
    public Task<List<Airport>> Airports(AirportFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Airport records
    /// </summary>
    public Task<MetadataDto> AirportsMeta(AirportFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Airport
    /// </summary>
    public Task<Airport> Airport(AirportWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Airport
    /// </summary>
    public Task UpdateAirport(AirportWhereUniqueInput uniqueId, AirportUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Schedules records to Airport
    /// </summary>
    public Task ConnectSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Disconnect multiple Schedules records from Airport
    /// </summary>
    public Task DisconnectSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Find multiple Schedules records for Airport
    /// </summary>
    public Task<List<Schedule>> FindSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleFindManyArgs ScheduleFindManyArgs
    );

    /// <summary>
    /// Update multiple Schedules records for Airport
    /// </summary>
    public Task UpdateSchedules(
        AirportWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );
}
