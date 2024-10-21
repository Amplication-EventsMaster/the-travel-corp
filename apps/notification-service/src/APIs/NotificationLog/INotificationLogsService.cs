using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;

namespace NotificationService.APIs;

public interface INotificationLogsService
{
    /// <summary>
    /// Create one NotificationLog
    /// </summary>
    public Task<NotificationLog> CreateNotificationLog(NotificationLogCreateInput notificationlog);

    /// <summary>
    /// Delete one NotificationLog
    /// </summary>
    public Task DeleteNotificationLog(NotificationLogWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many NotificationLogs
    /// </summary>
    public Task<List<NotificationLog>> NotificationLogs(NotificationLogFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about NotificationLog records
    /// </summary>
    public Task<MetadataDto> NotificationLogsMeta(NotificationLogFindManyArgs findManyArgs);

    /// <summary>
    /// Get one NotificationLog
    /// </summary>
    public Task<NotificationLog> NotificationLog(NotificationLogWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one NotificationLog
    /// </summary>
    public Task UpdateNotificationLog(
        NotificationLogWhereUniqueInput uniqueId,
        NotificationLogUpdateInput updateDto
    );

    /// <summary>
    /// Get a Notification record for NotificationLog
    /// </summary>
    public Task<Notification> GetNotification(NotificationLogWhereUniqueInput uniqueId);
}
