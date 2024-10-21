using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;

namespace NotificationService.APIs;

public interface INotificationSettingsService
{
    /// <summary>
    /// Create one NotificationSetting
    /// </summary>
    public Task<NotificationSetting> CreateNotificationSetting(
        NotificationSettingCreateInput notificationsetting
    );

    /// <summary>
    /// Delete one NotificationSetting
    /// </summary>
    public Task DeleteNotificationSetting(NotificationSettingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many NotificationSettings
    /// </summary>
    public Task<List<NotificationSetting>> NotificationSettings(
        NotificationSettingFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about NotificationSetting records
    /// </summary>
    public Task<MetadataDto> NotificationSettingsMeta(NotificationSettingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one NotificationSetting
    /// </summary>
    public Task<NotificationSetting> NotificationSetting(
        NotificationSettingWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one NotificationSetting
    /// </summary>
    public Task UpdateNotificationSetting(
        NotificationSettingWhereUniqueInput uniqueId,
        NotificationSettingUpdateInput updateDto
    );
}
