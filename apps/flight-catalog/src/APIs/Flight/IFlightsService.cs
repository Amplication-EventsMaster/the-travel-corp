using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;

namespace FlightCatalog.APIs;

public interface IFlightsService
{
    /// <summary>
    /// Create one Flight
    /// </summary>
    public Task<Flight> CreateFlight(FlightCreateInput flight);

    /// <summary>
    /// Delete one Flight
    /// </summary>
    public Task DeleteFlight(FlightWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Flights
    /// </summary>
    public Task<List<Flight>> Flights(FlightFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Flight records
    /// </summary>
    public Task<MetadataDto> FlightsMeta(FlightFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Flight
    /// </summary>
    public Task<Flight> Flight(FlightWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Flight
    /// </summary>
    public Task UpdateFlight(FlightWhereUniqueInput uniqueId, FlightUpdateInput updateDto);

    /// <summary>
    /// Get a Airline record for Flight
    /// </summary>
    public Task<Airline> GetAirline(FlightWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Route record for Flight
    /// </summary>
    public Task<Route> GetRoute(FlightWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Schedules records to Flight
    /// </summary>
    public Task ConnectSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Disconnect multiple Schedules records from Flight
    /// </summary>
    public Task DisconnectSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Find multiple Schedules records for Flight
    /// </summary>
    public Task<List<Schedule>> FindSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleFindManyArgs ScheduleFindManyArgs
    );

    /// <summary>
    /// Update multiple Schedules records for Flight
    /// </summary>
    public Task UpdateSchedules(
        FlightWhereUniqueInput uniqueId,
        ScheduleWhereUniqueInput[] schedulesId
    );

    /// <summary>
    /// Connect multiple Tickets records to Flight
    /// </summary>
    public Task ConnectTickets(FlightWhereUniqueInput uniqueId, TicketWhereUniqueInput[] ticketsId);

    /// <summary>
    /// Disconnect multiple Tickets records from Flight
    /// </summary>
    public Task DisconnectTickets(
        FlightWhereUniqueInput uniqueId,
        TicketWhereUniqueInput[] ticketsId
    );

    /// <summary>
    /// Find multiple Tickets records for Flight
    /// </summary>
    public Task<List<Ticket>> FindTickets(
        FlightWhereUniqueInput uniqueId,
        TicketFindManyArgs TicketFindManyArgs
    );

    /// <summary>
    /// Update multiple Tickets records for Flight
    /// </summary>
    public Task UpdateTickets(FlightWhereUniqueInput uniqueId, TicketWhereUniqueInput[] ticketsId);
}
