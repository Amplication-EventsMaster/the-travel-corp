using NotificationService.APIs.Dtos;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs.Extensions;

public static class UserNotificationsExtensions
{
    public static UserNotification ToDto(this UserNotificationDbModel model)
    {
        return new UserNotification
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Message = model.Message,
            Notification = model.NotificationId,
            Notifications = model.Notifications?.Select(x => x.Id).ToList(),
            Read = model.Read,
            UpdatedAt = model.UpdatedAt,
            User = model.User,
        };
    }

    public static UserNotificationDbModel ToModel(
        this UserNotificationUpdateInput updateDto,
        UserNotificationWhereUniqueInput uniqueId
    )
    {
        var userNotification = new UserNotificationDbModel
        {
            Id = uniqueId.Id,
            Message = updateDto.Message,
            Read = updateDto.Read,
            User = updateDto.User
        };

        if (updateDto.CreatedAt != null)
        {
            userNotification.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Notification != null)
        {
            userNotification.NotificationId = updateDto.Notification;
        }
        if (updateDto.UpdatedAt != null)
        {
            userNotification.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return userNotification;
    }
}
