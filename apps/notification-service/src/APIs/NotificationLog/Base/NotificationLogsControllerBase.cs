using Microsoft.AspNetCore.Mvc;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;

namespace NotificationService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class NotificationLogsControllerBase : ControllerBase
{
    protected readonly INotificationLogsService _service;

    public NotificationLogsControllerBase(INotificationLogsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one NotificationLog
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<NotificationLog>> CreateNotificationLog(
        NotificationLogCreateInput input
    )
    {
        var notificationLog = await _service.CreateNotificationLog(input);

        return CreatedAtAction(
            nameof(NotificationLog),
            new { id = notificationLog.Id },
            notificationLog
        );
    }

    /// <summary>
    /// Delete one NotificationLog
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteNotificationLog(
        [FromRoute()] NotificationLogWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteNotificationLog(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many NotificationLogs
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<NotificationLog>>> NotificationLogs(
        [FromQuery()] NotificationLogFindManyArgs filter
    )
    {
        return Ok(await _service.NotificationLogs(filter));
    }

    /// <summary>
    /// Meta data about NotificationLog records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> NotificationLogsMeta(
        [FromQuery()] NotificationLogFindManyArgs filter
    )
    {
        return Ok(await _service.NotificationLogsMeta(filter));
    }

    /// <summary>
    /// Get one NotificationLog
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<NotificationLog>> NotificationLog(
        [FromRoute()] NotificationLogWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.NotificationLog(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one NotificationLog
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateNotificationLog(
        [FromRoute()] NotificationLogWhereUniqueInput uniqueId,
        [FromQuery()] NotificationLogUpdateInput notificationLogUpdateDto
    )
    {
        try
        {
            await _service.UpdateNotificationLog(uniqueId, notificationLogUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Notification record for NotificationLog
    /// </summary>
    [HttpGet("{Id}/notification")]
    public async Task<ActionResult<List<Notification>>> GetNotification(
        [FromRoute()] NotificationLogWhereUniqueInput uniqueId
    )
    {
        var notification = await _service.GetNotification(uniqueId);
        return Ok(notification);
    }
}
