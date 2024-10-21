using FlightCatalog.APIs.Dtos;
using FlightCatalog.Infrastructure.Models;

namespace FlightCatalog.APIs.Extensions;

public static class AirportsExtensions
{
    public static Airport ToDto(this AirportDbModel model)
    {
        return new Airport
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Location = model.Location,
            Name = model.Name,
            Schedules = model.Schedules?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AirportDbModel ToModel(
        this AirportUpdateInput updateDto,
        AirportWhereUniqueInput uniqueId
    )
    {
        var airport = new AirportDbModel
        {
            Id = uniqueId.Id,
            Location = updateDto.Location,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            airport.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            airport.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return airport;
    }
}
