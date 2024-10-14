using SampleService.APIs.Dtos;
using SampleService.Infrastructure.Models;

namespace SampleService.APIs.Extensions;

public static class LocationsExtensions
{
    public static Location ToDto(this LocationDbModel model)
    {
        return new Location
        {
            Address = model.Address,
            City = model.City,
            Country = model.Country,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LocationDbModel ToModel(
        this LocationUpdateInput updateDto,
        LocationWhereUniqueInput uniqueId
    )
    {
        var location = new LocationDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            City = updateDto.City,
            Country = updateDto.Country
        };

        if (updateDto.CreatedAt != null)
        {
            location.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            location.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return location;
    }
}
