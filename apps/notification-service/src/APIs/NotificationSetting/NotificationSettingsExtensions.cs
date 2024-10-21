using NotificationService.APIs.Dtos;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs.Extensions;

public static class NotificationSettingsExtensions
{
    public static NotificationSetting ToDto(this NotificationSettingDbModel model)
    {
        return new NotificationSetting
        {
            CreatedAt = model.CreatedAt,
            Frequency = model.Frequency,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            User = model.User,
        };
    }

    public static NotificationSettingDbModel ToModel(
        this NotificationSettingUpdateInput updateDto,
        NotificationSettingWhereUniqueInput uniqueId
    )
    {
        var notificationSetting = new NotificationSettingDbModel
        {
            Id = uniqueId.Id,
            Frequency = updateDto.Frequency,
            User = updateDto.User
        };

        if (updateDto.CreatedAt != null)
        {
            notificationSetting.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            notificationSetting.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return notificationSetting;
    }
}
