using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;

namespace NotificationService.APIs;

public interface IUserNotificationsService
{
    /// <summary>
    /// Create one UserNotification
    /// </summary>
    public Task<UserNotification> CreateUserNotification(
        UserNotificationCreateInput usernotification
    );

    /// <summary>
    /// Delete one UserNotification
    /// </summary>
    public Task DeleteUserNotification(UserNotificationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many UserNotifications
    /// </summary>
    public Task<List<UserNotification>> UserNotifications(
        UserNotificationFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about UserNotification records
    /// </summary>
    public Task<MetadataDto> UserNotificationsMeta(UserNotificationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one UserNotification
    /// </summary>
    public Task<UserNotification> UserNotification(UserNotificationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one UserNotification
    /// </summary>
    public Task UpdateUserNotification(
        UserNotificationWhereUniqueInput uniqueId,
        UserNotificationUpdateInput updateDto
    );

    /// <summary>
    /// Get a Notification record for UserNotification
    /// </summary>
    public Task<Notification> GetNotification(UserNotificationWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Notifications records to UserNotification
    /// </summary>
    public Task ConnectNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationWhereUniqueInput[] notificationsId
    );

    /// <summary>
    /// Disconnect multiple Notifications records from UserNotification
    /// </summary>
    public Task DisconnectNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationWhereUniqueInput[] notificationsId
    );

    /// <summary>
    /// Find multiple Notifications records for UserNotification
    /// </summary>
    public Task<List<Notification>> FindNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationFindManyArgs NotificationFindManyArgs
    );

    /// <summary>
    /// Update multiple Notifications records for UserNotification
    /// </summary>
    public Task UpdateNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationWhereUniqueInput[] notificationsId
    );
}
