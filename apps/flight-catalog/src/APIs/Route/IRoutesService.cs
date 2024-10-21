using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;

namespace FlightCatalog.APIs;

public interface IRoutesService
{
    /// <summary>
    /// Create one Route
    /// </summary>
    public Task<Route> CreateRoute(RouteCreateInput route);

    /// <summary>
    /// Delete one Route
    /// </summary>
    public Task DeleteRoute(RouteWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Routes
    /// </summary>
    public Task<List<Route>> Routes(RouteFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Route records
    /// </summary>
    public Task<MetadataDto> RoutesMeta(RouteFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Route
    /// </summary>
    public Task<Route> Route(RouteWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Route
    /// </summary>
    public Task UpdateRoute(RouteWhereUniqueInput uniqueId, RouteUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Flights records to Route
    /// </summary>
    public Task ConnectFlights(RouteWhereUniqueInput uniqueId, FlightWhereUniqueInput[] flightsId);

    /// <summary>
    /// Disconnect multiple Flights records from Route
    /// </summary>
    public Task DisconnectFlights(
        RouteWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] flightsId
    );

    /// <summary>
    /// Find multiple Flights records for Route
    /// </summary>
    public Task<List<Flight>> FindFlights(
        RouteWhereUniqueInput uniqueId,
        FlightFindManyArgs FlightFindManyArgs
    );

    /// <summary>
    /// Update multiple Flights records for Route
    /// </summary>
    public Task UpdateFlights(RouteWhereUniqueInput uniqueId, FlightWhereUniqueInput[] flightsId);
}
