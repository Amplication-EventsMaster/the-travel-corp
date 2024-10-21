using FlightCatalog.APIs.Dtos;
using FlightCatalog.Infrastructure.Models;

namespace FlightCatalog.APIs.Extensions;

public static class FlightsExtensions
{
    public static Flight ToDto(this FlightDbModel model)
    {
        return new Flight
        {
            Airline = model.AirlineId,
            ArrivalTime = model.ArrivalTime,
            CreatedAt = model.CreatedAt,
            DepartureTime = model.DepartureTime,
            FlightNumber = model.FlightNumber,
            Id = model.Id,
            Route = model.RouteId,
            Schedules = model.Schedules?.Select(x => x.Id).ToList(),
            Tickets = model.Tickets?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FlightDbModel ToModel(
        this FlightUpdateInput updateDto,
        FlightWhereUniqueInput uniqueId
    )
    {
        var flight = new FlightDbModel
        {
            Id = uniqueId.Id,
            ArrivalTime = updateDto.ArrivalTime,
            DepartureTime = updateDto.DepartureTime,
            FlightNumber = updateDto.FlightNumber
        };

        if (updateDto.Airline != null)
        {
            flight.AirlineId = updateDto.Airline;
        }
        if (updateDto.CreatedAt != null)
        {
            flight.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Route != null)
        {
            flight.RouteId = updateDto.Route;
        }
        if (updateDto.UpdatedAt != null)
        {
            flight.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return flight;
    }
}
