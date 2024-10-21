using NotificationService.APIs.Dtos;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs.Extensions;

public static class NotificationTypesExtensions
{
    public static NotificationType ToDto(this NotificationTypeDbModel model)
    {
        return new NotificationType
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            Notifications = model.Notifications?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static NotificationTypeDbModel ToModel(
        this NotificationTypeUpdateInput updateDto,
        NotificationTypeWhereUniqueInput uniqueId
    )
    {
        var notificationType = new NotificationTypeDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            notificationType.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            notificationType.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return notificationType;
    }
}
