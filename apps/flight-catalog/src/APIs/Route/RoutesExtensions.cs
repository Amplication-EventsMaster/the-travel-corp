using FlightCatalog.APIs.Dtos;
using FlightCatalog.Infrastructure.Models;

namespace FlightCatalog.APIs.Extensions;

public static class RoutesExtensions
{
    public static Route ToDto(this RouteDbModel model)
    {
        return new Route
        {
            CreatedAt = model.CreatedAt,
            Destination = model.Destination,
            Flights = model.Flights?.Select(x => x.Id).ToList(),
            Id = model.Id,
            Origin = model.Origin,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RouteDbModel ToModel(
        this RouteUpdateInput updateDto,
        RouteWhereUniqueInput uniqueId
    )
    {
        var route = new RouteDbModel
        {
            Id = uniqueId.Id,
            Destination = updateDto.Destination,
            Origin = updateDto.Origin
        };

        if (updateDto.CreatedAt != null)
        {
            route.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            route.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return route;
    }
}
