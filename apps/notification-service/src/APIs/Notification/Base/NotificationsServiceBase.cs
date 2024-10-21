using Microsoft.EntityFrameworkCore;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;
using NotificationService.APIs.Extensions;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs;

public abstract class NotificationsServiceBase : INotificationsService
{
    protected readonly NotificationServiceDbContext _context;

    public NotificationsServiceBase(NotificationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Notification
    /// </summary>
    public async Task<Notification> CreateNotification(NotificationCreateInput createDto)
    {
        var notification = new NotificationDbModel
        {
            Content = createDto.Content,
            CreatedAt = createDto.CreatedAt,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            notification.Id = createDto.Id;
        }
        if (createDto.NotificationLogs != null)
        {
            notification.NotificationLogs = await _context
                .NotificationLogs.Where(notificationLog =>
                    createDto.NotificationLogs.Select(t => t.Id).Contains(notificationLog.Id)
                )
                .ToListAsync();
        }

        if (createDto.NotificationType != null)
        {
            notification.NotificationType = await _context
                .NotificationTypes.Where(notificationType =>
                    createDto.NotificationType.Id == notificationType.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.UserNotification != null)
        {
            notification.UserNotification = await _context
                .UserNotifications.Where(userNotification =>
                    createDto.UserNotification.Id == userNotification.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.UserNotifications != null)
        {
            notification.UserNotifications = await _context
                .UserNotifications.Where(userNotification =>
                    createDto.UserNotifications.Select(t => t.Id).Contains(userNotification.Id)
                )
                .ToListAsync();
        }

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<NotificationDbModel>(notification.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Notification
    /// </summary>
    public async Task DeleteNotification(NotificationWhereUniqueInput uniqueId)
    {
        var notification = await _context.Notifications.FindAsync(uniqueId.Id);
        if (notification == null)
        {
            throw new NotFoundException();
        }

        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Notifications
    /// </summary>
    public async Task<List<Notification>> Notifications(NotificationFindManyArgs findManyArgs)
    {
        var notifications = await _context
            .Notifications.Include(x => x.UserNotification)
            .Include(x => x.NotificationType)
            .Include(x => x.NotificationLogs)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return notifications.ConvertAll(notification => notification.ToDto());
    }

    /// <summary>
    /// Meta data about Notification records
    /// </summary>
    public async Task<MetadataDto> NotificationsMeta(NotificationFindManyArgs findManyArgs)
    {
        var count = await _context.Notifications.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Notification
    /// </summary>
    public async Task<Notification> Notification(NotificationWhereUniqueInput uniqueId)
    {
        var notifications = await this.Notifications(
            new NotificationFindManyArgs { Where = new NotificationWhereInput { Id = uniqueId.Id } }
        );
        var notification = notifications.FirstOrDefault();
        if (notification == null)
        {
            throw new NotFoundException();
        }

        return notification;
    }

    /// <summary>
    /// Update one Notification
    /// </summary>
    public async Task UpdateNotification(
        NotificationWhereUniqueInput uniqueId,
        NotificationUpdateInput updateDto
    )
    {
        var notification = updateDto.ToModel(uniqueId);

        if (updateDto.NotificationLogs != null)
        {
            notification.NotificationLogs = await _context
                .NotificationLogs.Where(notificationLog =>
                    updateDto.NotificationLogs.Select(t => t).Contains(notificationLog.Id)
                )
                .ToListAsync();
        }

        if (updateDto.NotificationType != null)
        {
            notification.NotificationType = await _context
                .NotificationTypes.Where(notificationType =>
                    updateDto.NotificationType == notificationType.Id
                )
                .FirstOrDefaultAsync();
        }

        if (updateDto.UserNotification != null)
        {
            notification.UserNotification = await _context
                .UserNotifications.Where(userNotification =>
                    updateDto.UserNotification == userNotification.Id
                )
                .FirstOrDefaultAsync();
        }

        if (updateDto.UserNotifications != null)
        {
            notification.UserNotifications = await _context
                .UserNotifications.Where(userNotification =>
                    updateDto.UserNotifications.Select(t => t).Contains(userNotification.Id)
                )
                .ToListAsync();
        }

        _context.Entry(notification).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Notifications.Any(e => e.Id == notification.Id))
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
    /// Connect multiple NotificationLogs records to Notification
    /// </summary>
    public async Task ConnectNotificationLogs(
        NotificationWhereUniqueInput uniqueId,
        NotificationLogWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Notifications.Include(x => x.NotificationLogs)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .NotificationLogs.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.NotificationLogs);

        foreach (var child in childrenToConnect)
        {
            parent.NotificationLogs.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple NotificationLogs records from Notification
    /// </summary>
    public async Task DisconnectNotificationLogs(
        NotificationWhereUniqueInput uniqueId,
        NotificationLogWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Notifications.Include(x => x.NotificationLogs)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .NotificationLogs.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.NotificationLogs?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple NotificationLogs records for Notification
    /// </summary>
    public async Task<List<NotificationLog>> FindNotificationLogs(
        NotificationWhereUniqueInput uniqueId,
        NotificationLogFindManyArgs notificationFindManyArgs
    )
    {
        var notificationLogs = await _context
            .NotificationLogs.Where(m => m.NotificationId == uniqueId.Id)
            .ApplyWhere(notificationFindManyArgs.Where)
            .ApplySkip(notificationFindManyArgs.Skip)
            .ApplyTake(notificationFindManyArgs.Take)
            .ApplyOrderBy(notificationFindManyArgs.SortBy)
            .ToListAsync();

        return notificationLogs.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple NotificationLogs records for Notification
    /// </summary>
    public async Task UpdateNotificationLogs(
        NotificationWhereUniqueInput uniqueId,
        NotificationLogWhereUniqueInput[] childrenIds
    )
    {
        var notification = await _context
            .Notifications.Include(t => t.NotificationLogs)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (notification == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .NotificationLogs.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        notification.NotificationLogs = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a NotificationType record for Notification
    /// </summary>
    public async Task<NotificationType> GetNotificationType(NotificationWhereUniqueInput uniqueId)
    {
        var notification = await _context
            .Notifications.Where(notification => notification.Id == uniqueId.Id)
            .Include(notification => notification.NotificationType)
            .FirstOrDefaultAsync();
        if (notification == null)
        {
            throw new NotFoundException();
        }
        return notification.NotificationType.ToDto();
    }

    /// <summary>
    /// Get a UserNotification record for Notification
    /// </summary>
    public async Task<UserNotification> GetUserNotification(NotificationWhereUniqueInput uniqueId)
    {
        var notification = await _context
            .Notifications.Where(notification => notification.Id == uniqueId.Id)
            .Include(notification => notification.UserNotification)
            .FirstOrDefaultAsync();
        if (notification == null)
        {
            throw new NotFoundException();
        }
        return notification.UserNotification.ToDto();
    }

    /// <summary>
    /// Connect multiple UserNotifications records to Notification
    /// </summary>
    public async Task ConnectUserNotifications(
        NotificationWhereUniqueInput uniqueId,
        UserNotificationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Notifications.Include(x => x.UserNotifications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .UserNotifications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.UserNotifications);

        foreach (var child in childrenToConnect)
        {
            parent.UserNotifications.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple UserNotifications records from Notification
    /// </summary>
    public async Task DisconnectUserNotifications(
        NotificationWhereUniqueInput uniqueId,
        UserNotificationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Notifications.Include(x => x.UserNotifications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .UserNotifications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.UserNotifications?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple UserNotifications records for Notification
    /// </summary>
    public async Task<List<UserNotification>> FindUserNotifications(
        NotificationWhereUniqueInput uniqueId,
        UserNotificationFindManyArgs notificationFindManyArgs
    )
    {
        var userNotifications = await _context
            .UserNotifications.Where(m => m.NotificationId == uniqueId.Id)
            .ApplyWhere(notificationFindManyArgs.Where)
            .ApplySkip(notificationFindManyArgs.Skip)
            .ApplyTake(notificationFindManyArgs.Take)
            .ApplyOrderBy(notificationFindManyArgs.SortBy)
            .ToListAsync();

        return userNotifications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple UserNotifications records for Notification
    /// </summary>
    public async Task UpdateUserNotifications(
        NotificationWhereUniqueInput uniqueId,
        UserNotificationWhereUniqueInput[] childrenIds
    )
    {
        var notification = await _context
            .Notifications.Include(t => t.UserNotifications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (notification == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .UserNotifications.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        notification.UserNotifications = children;
        await _context.SaveChangesAsync();
    }
}
