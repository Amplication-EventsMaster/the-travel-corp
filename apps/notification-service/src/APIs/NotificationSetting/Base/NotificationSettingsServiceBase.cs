using Microsoft.EntityFrameworkCore;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;
using NotificationService.APIs.Extensions;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs;

public abstract class NotificationSettingsServiceBase : INotificationSettingsService
{
    protected readonly NotificationServiceDbContext _context;

    public NotificationSettingsServiceBase(NotificationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one NotificationSetting
    /// </summary>
    public async Task<NotificationSetting> CreateNotificationSetting(
        NotificationSettingCreateInput createDto
    )
    {
        var notificationSetting = new NotificationSettingDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Frequency = createDto.Frequency,
            UpdatedAt = createDto.UpdatedAt,
            User = createDto.User
        };

        if (createDto.Id != null)
        {
            notificationSetting.Id = createDto.Id;
        }

        _context.NotificationSettings.Add(notificationSetting);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<NotificationSettingDbModel>(notificationSetting.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one NotificationSetting
    /// </summary>
    public async Task DeleteNotificationSetting(NotificationSettingWhereUniqueInput uniqueId)
    {
        var notificationSetting = await _context.NotificationSettings.FindAsync(uniqueId.Id);
        if (notificationSetting == null)
        {
            throw new NotFoundException();
        }

        _context.NotificationSettings.Remove(notificationSetting);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many NotificationSettings
    /// </summary>
    public async Task<List<NotificationSetting>> NotificationSettings(
        NotificationSettingFindManyArgs findManyArgs
    )
    {
        var notificationSettings = await _context
            .NotificationSettings.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return notificationSettings.ConvertAll(notificationSetting => notificationSetting.ToDto());
    }

    /// <summary>
    /// Meta data about NotificationSetting records
    /// </summary>
    public async Task<MetadataDto> NotificationSettingsMeta(
        NotificationSettingFindManyArgs findManyArgs
    )
    {
        var count = await _context.NotificationSettings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one NotificationSetting
    /// </summary>
    public async Task<NotificationSetting> NotificationSetting(
        NotificationSettingWhereUniqueInput uniqueId
    )
    {
        var notificationSettings = await this.NotificationSettings(
            new NotificationSettingFindManyArgs
            {
                Where = new NotificationSettingWhereInput { Id = uniqueId.Id }
            }
        );
        var notificationSetting = notificationSettings.FirstOrDefault();
        if (notificationSetting == null)
        {
            throw new NotFoundException();
        }

        return notificationSetting;
    }

    /// <summary>
    /// Update one NotificationSetting
    /// </summary>
    public async Task UpdateNotificationSetting(
        NotificationSettingWhereUniqueInput uniqueId,
        NotificationSettingUpdateInput updateDto
    )
    {
        var notificationSetting = updateDto.ToModel(uniqueId);

        _context.Entry(notificationSetting).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.NotificationSettings.Any(e => e.Id == notificationSetting.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
