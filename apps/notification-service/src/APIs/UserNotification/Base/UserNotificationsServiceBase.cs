using Microsoft.EntityFrameworkCore;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;
using NotificationService.APIs.Extensions;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Models;

namespace NotificationService.APIs;

public abstract class UserNotificationsServiceBase : IUserNotificationsService
{
    protected readonly NotificationServiceDbContext _context;

    public UserNotificationsServiceBase(NotificationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one UserNotification
    /// </summary>
    public async Task<UserNotification> CreateUserNotification(
        UserNotificationCreateInput createDto
    )
    {
        var userNotification = new UserNotificationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Message = createDto.Message,
            Read = createDto.Read,
            UpdatedAt = createDto.UpdatedAt,
            User = createDto.User
        };

        if (createDto.Id != null)
        {
            userNotification.Id = createDto.Id;
        }
        if (createDto.Notification != null)
        {
            userNotification.Notification = await _context
                .Notifications.Where(notification => createDto.Notification.Id == notification.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Notifications != null)
        {
            userNotification.Notifications = await _context
                .Notifications.Where(notification =>
                    createDto.Notifications.Select(t => t.Id).Contains(notification.Id)
                )
                .ToListAsync();
        }

        _context.UserNotifications.Add(userNotification);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserNotificationDbModel>(userNotification.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one UserNotification
    /// </summary>
    public async Task DeleteUserNotification(UserNotificationWhereUniqueInput uniqueId)
    {
        var userNotification = await _context.UserNotifications.FindAsync(uniqueId.Id);
        if (userNotification == null)
        {
            throw new NotFoundException();
        }

        _context.UserNotifications.Remove(userNotification);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many UserNotifications
    /// </summary>
    public async Task<List<UserNotification>> UserNotifications(
        UserNotificationFindManyArgs findManyArgs
    )
    {
        var userNotifications = await _context
            .UserNotifications.Include(x => x.Notification)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return userNotifications.ConvertAll(userNotification => userNotification.ToDto());
    }

    /// <summary>
    /// Meta data about UserNotification records
    /// </summary>
    public async Task<MetadataDto> UserNotificationsMeta(UserNotificationFindManyArgs findManyArgs)
    {
        var count = await _context.UserNotifications.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one UserNotification
    /// </summary>
    public async Task<UserNotification> UserNotification(UserNotificationWhereUniqueInput uniqueId)
    {
        var userNotifications = await this.UserNotifications(
            new UserNotificationFindManyArgs
            {
                Where = new UserNotificationWhereInput { Id = uniqueId.Id }
            }
        );
        var userNotification = userNotifications.FirstOrDefault();
        if (userNotification == null)
        {
            throw new NotFoundException();
        }

        return userNotification;
    }

    /// <summary>
    /// Update one UserNotification
    /// </summary>
    public async Task UpdateUserNotification(
        UserNotificationWhereUniqueInput uniqueId,
        UserNotificationUpdateInput updateDto
    )
    {
        var userNotification = updateDto.ToModel(uniqueId);

        if (updateDto.Notification != null)
        {
            userNotification.Notification = await _context
                .Notifications.Where(notification => updateDto.Notification == notification.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Notifications != null)
        {
            userNotification.Notifications = await _context
                .Notifications.Where(notification =>
                    updateDto.Notifications.Select(t => t).Contains(notification.Id)
                )
                .ToListAsync();
        }

        _context.Entry(userNotification).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.UserNotifications.Any(e => e.Id == userNotification.Id))
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
    /// Get a Notification record for UserNotification
    /// </summary>
    public async Task<Notification> GetNotification(UserNotificationWhereUniqueInput uniqueId)
    {
        var userNotification = await _context
            .UserNotifications.Where(userNotification => userNotification.Id == uniqueId.Id)
            .Include(userNotification => userNotification.Notification)
            .FirstOrDefaultAsync();
        if (userNotification == null)
        {
            throw new NotFoundException();
        }
        return userNotification.Notification.ToDto();
    }

    /// <summary>
    /// Connect multiple Notifications records to UserNotification
    /// </summary>
    public async Task ConnectNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .UserNotifications.Include(x => x.Notifications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Notifications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Notifications);

        foreach (var child in childrenToConnect)
        {
            parent.Notifications.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Notifications records from UserNotification
    /// </summary>
    public async Task DisconnectNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .UserNotifications.Include(x => x.Notifications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Notifications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Notifications?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Notifications records for UserNotification
    /// </summary>
    public async Task<List<Notification>> FindNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationFindManyArgs userNotificationFindManyArgs
    )
    {
        var notifications = await _context
            .Notifications.Where(m => m.UserNotificationId == uniqueId.Id)
            .ApplyWhere(userNotificationFindManyArgs.Where)
            .ApplySkip(userNotificationFindManyArgs.Skip)
            .ApplyTake(userNotificationFindManyArgs.Take)
            .ApplyOrderBy(userNotificationFindManyArgs.SortBy)
            .ToListAsync();

        return notifications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Notifications records for UserNotification
    /// </summary>
    public async Task UpdateNotifications(
        UserNotificationWhereUniqueInput uniqueId,
        NotificationWhereUniqueInput[] childrenIds
    )
    {
        var userNotification = await _context
            .UserNotifications.Include(t => t.Notifications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (userNotification == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Notifications.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        userNotification.Notifications = children;
        await _context.SaveChangesAsync();
    }
}
