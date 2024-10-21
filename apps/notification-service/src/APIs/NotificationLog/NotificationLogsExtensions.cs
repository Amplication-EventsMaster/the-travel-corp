using NotificationService.APIs.Dtos;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs.Extensions;

public static class NotificationLogsExtensions
{
    public static NotificationLog ToDto(this NotificationLogDbModel model)
    {
        return new NotificationLog
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Notification = model.NotificationId,
            Status = model.Status,
            Timestamp = model.Timestamp,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static NotificationLogDbModel ToModel(
        this NotificationLogUpdateInput updateDto,
        NotificationLogWhereUniqueInput uniqueId
    )
    {
        var notificationLog = new NotificationLogDbModel
        {
            Id = uniqueId.Id,
            Status = updateDto.Status,
            Timestamp = updateDto.Timestamp
        };

        if (updateDto.CreatedAt != null)
        {
            notificationLog.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Notification != null)
        {
            notificationLog.NotificationId = updateDto.Notification;
        }
        if (updateDto.UpdatedAt != null)
        {
            notificationLog.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return notificationLog;
    }
}
