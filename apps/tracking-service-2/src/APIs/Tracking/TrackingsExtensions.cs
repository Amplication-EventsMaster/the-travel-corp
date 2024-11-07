using TrackingService_2.APIs.Dtos;
using TrackingService_2.Infrastructure.Models;

namespace TrackingService_2.APIs.Extensions;

public static class TrackingsExtensions
{
    public static Tracking ToDto(this TrackingDbModel model)
    {
        return new Tracking
        {
            Comment = model.Comment,
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TrackingDbModel ToModel(
        this TrackingUpdateInput updateDto,
        TrackingWhereUniqueInput uniqueId
    )
    {
        var tracking = new TrackingDbModel { Id = uniqueId.Id, Comment = updateDto.Comment };

        if (updateDto.CreatedAt != null)
        {
            tracking.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            tracking.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            tracking.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return tracking;
    }
}
