using Microsoft.AspNetCore.Mvc;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;

namespace NotificationService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class NotificationsControllerBase : ControllerBase
{
    protected readonly INotificationsService _service;

    public NotificationsControllerBase(INotificationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Notification
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Notification>> CreateNotification(NotificationCreateInput input)
    {
        var notification = await _service.CreateNotification(input);

        return CreatedAtAction(nameof(Notification), new { id = notification.Id }, notification);
    }

    /// <summary>
    /// Delete one Notification
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteNotification(
        [FromRoute()] NotificationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteNotification(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Notifications
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Notification>>> Notifications(
        [FromQuery()] NotificationFindManyArgs filter
    )
    {
        return Ok(await _service.Notifications(filter));
    }

    /// <summary>
    /// Meta data about Notification records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> NotificationsMeta(
        [FromQuery()] NotificationFindManyArgs filter
    )
    {
        return Ok(await _service.NotificationsMeta(filter));
    }

    /// <summary>
    /// Get one Notification
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Notification>> Notification(
        [FromRoute()] NotificationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Notification(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Notification
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateNotification(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromQuery()] NotificationUpdateInput notificationUpdateDto
    )
    {
        try
        {
            await _service.UpdateNotification(uniqueId, notificationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple NotificationLogs records to Notification
    /// </summary>
    [HttpPost("{Id}/notificationLogs")]
    public async Task<ActionResult> ConnectNotificationLogs(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromQuery()] NotificationLogWhereUniqueInput[] notificationLogsId
    )
    {
        try
        {
            await _service.ConnectNotificationLogs(uniqueId, notificationLogsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple NotificationLogs records from Notification
    /// </summary>
    [HttpDelete("{Id}/notificationLogs")]
    public async Task<ActionResult> DisconnectNotificationLogs(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromBody()] NotificationLogWhereUniqueInput[] notificationLogsId
    )
    {
        try
        {
            await _service.DisconnectNotificationLogs(uniqueId, notificationLogsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple NotificationLogs records for Notification
    /// </summary>
    [HttpGet("{Id}/notificationLogs")]
    public async Task<ActionResult<List<NotificationLog>>> FindNotificationLogs(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromQuery()] NotificationLogFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindNotificationLogs(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple NotificationLogs records for Notification
    /// </summary>
    [HttpPatch("{Id}/notificationLogs")]
    public async Task<ActionResult> UpdateNotificationLogs(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromBody()] NotificationLogWhereUniqueInput[] notificationLogsId
    )
    {
        try
        {
            await _service.UpdateNotificationLogs(uniqueId, notificationLogsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a NotificationType record for Notification
    /// </summary>
    [HttpGet("{Id}/notificationType")]
    public async Task<ActionResult<List<NotificationType>>> GetNotificationType(
        [FromRoute()] NotificationWhereUniqueInput uniqueId
    )
    {
        var notificationType = await _service.GetNotificationType(uniqueId);
        return Ok(notificationType);
    }

    /// <summary>
    /// Get a UserNotification record for Notification
    /// </summary>
    [HttpGet("{Id}/userNotification")]
    public async Task<ActionResult<List<UserNotification>>> GetUserNotification(
        [FromRoute()] NotificationWhereUniqueInput uniqueId
    )
    {
        var userNotification = await _service.GetUserNotification(uniqueId);
        return Ok(userNotification);
    }

    /// <summary>
    /// Connect multiple UserNotifications records to Notification
    /// </summary>
    [HttpPost("{Id}/userNotifications")]
    public async Task<ActionResult> ConnectUserNotifications(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromQuery()] UserNotificationWhereUniqueInput[] userNotificationsId
    )
    {
        try
        {
            await _service.ConnectUserNotifications(uniqueId, userNotificationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple UserNotifications records from Notification
    /// </summary>
    [HttpDelete("{Id}/userNotifications")]
    public async Task<ActionResult> DisconnectUserNotifications(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromBody()] UserNotificationWhereUniqueInput[] userNotificationsId
    )
    {
        try
        {
            await _service.DisconnectUserNotifications(uniqueId, userNotificationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple UserNotifications records for Notification
    /// </summary>
    [HttpGet("{Id}/userNotifications")]
    public async Task<ActionResult<List<UserNotification>>> FindUserNotifications(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromQuery()] UserNotificationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindUserNotifications(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple UserNotifications records for Notification
    /// </summary>
    [HttpPatch("{Id}/userNotifications")]
    public async Task<ActionResult> UpdateUserNotifications(
        [FromRoute()] NotificationWhereUniqueInput uniqueId,
        [FromBody()] UserNotificationWhereUniqueInput[] userNotificationsId
    )
    {
        try
        {
            await _service.UpdateUserNotifications(uniqueId, userNotificationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
