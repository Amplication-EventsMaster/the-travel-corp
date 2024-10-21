using NotificationService.APIs.Dtos;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs.Extensions;

public static class NotificationsExtensions
{
    public static Notification ToDto(this NotificationDbModel model)
    {
        return new Notification
        {
            Content = model.Content,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            NotificationLogs = model.NotificationLogs?.Select(x => x.Id).ToList(),
            NotificationType = model.NotificationTypeId,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
            UserNotification = model.UserNotificationId,
            UserNotifications = model.UserNotifications?.Select(x => x.Id).ToList(),
        };
    }

    public static NotificationDbModel ToModel(
        this NotificationUpdateInput updateDto,
        NotificationWhereUniqueInput uniqueId
    )
    {
        var notification = new NotificationDbModel
        {
            Id = uniqueId.Id,
            Content = updateDto.Content,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            notification.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.NotificationType != null)
        {
            notification.NotificationTypeId = updateDto.NotificationType;
        }
        if (updateDto.UpdatedAt != null)
        {
            notification.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.UserNotification != null)
        {
            notification.UserNotificationId = updateDto.UserNotification;
        }

        return notification;
    }
}
