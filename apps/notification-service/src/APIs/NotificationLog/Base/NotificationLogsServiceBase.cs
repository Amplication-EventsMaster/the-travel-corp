using Microsoft.EntityFrameworkCore;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;
using NotificationService.APIs.Extensions;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs;

public abstract class NotificationLogsServiceBase : INotificationLogsService
{
    protected readonly NotificationServiceDbContext _context;

    public NotificationLogsServiceBase(NotificationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one NotificationLog
    /// </summary>
    public async Task<NotificationLog> CreateNotificationLog(NotificationLogCreateInput createDto)
    {
        var notificationLog = new NotificationLogDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            Timestamp = createDto.Timestamp,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            notificationLog.Id = createDto.Id;
        }
        if (createDto.Notification != null)
        {
            notificationLog.Notification = await _context
                .Notifications.Where(notification => createDto.Notification.Id == notification.Id)
                .FirstOrDefaultAsync();
        }

        _context.NotificationLogs.Add(notificationLog);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<NotificationLogDbModel>(notificationLog.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one NotificationLog
    /// </summary>
    public async Task DeleteNotificationLog(NotificationLogWhereUniqueInput uniqueId)
    {
        var notificationLog = await _context.NotificationLogs.FindAsync(uniqueId.Id);
        if (notificationLog == null)
        {
            throw new NotFoundException();
        }

        _context.NotificationLogs.Remove(notificationLog);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many NotificationLogs
    /// </summary>
    public async Task<List<NotificationLog>> NotificationLogs(
        NotificationLogFindManyArgs findManyArgs
    )
    {
        var notificationLogs = await _context
            .NotificationLogs.Include(x => x.Notification)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return notificationLogs.ConvertAll(notificationLog => notificationLog.ToDto());
    }

    /// <summary>
    /// Meta data about NotificationLog records
    /// </summary>
    public async Task<MetadataDto> NotificationLogsMeta(NotificationLogFindManyArgs findManyArgs)
    {
        var count = await _context.NotificationLogs.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one NotificationLog
    /// </summary>
    public async Task<NotificationLog> NotificationLog(NotificationLogWhereUniqueInput uniqueId)
    {
        var notificationLogs = await this.NotificationLogs(
            new NotificationLogFindManyArgs
            {
                Where = new NotificationLogWhereInput { Id = uniqueId.Id }
            }
        );
        var notificationLog = notificationLogs.FirstOrDefault();
        if (notificationLog == null)
        {
            throw new NotFoundException();
        }

        return notificationLog;
    }

    /// <summary>
    /// Update one NotificationLog
    /// </summary>
    public async Task UpdateNotificationLog(
        NotificationLogWhereUniqueInput uniqueId,
        NotificationLogUpdateInput updateDto
    )
    {
        var notificationLog = updateDto.ToModel(uniqueId);

        if (updateDto.Notification != null)
        {
            notificationLog.Notification = await _context
                .Notifications.Where(notification => updateDto.Notification == notification.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(notificationLog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.NotificationLogs.Any(e => e.Id == notificationLog.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a Notification record for NotificationLog
    /// </summary>
    public async Task<Notification> GetNotification(NotificationLogWhereUniqueInput uniqueId)
    {
        var notificationLog = await _context
            .NotificationLogs.Where(notificationLog => notificationLog.Id == uniqueId.Id)
            .Include(notificationLog => notificationLog.Notification)
            .FirstOrDefaultAsync();
        if (notificationLog == null)
        {
            throw new NotFoundException();
        }
        return notificationLog.Notification.ToDto();
    }
}
