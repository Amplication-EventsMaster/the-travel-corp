using Microsoft.AspNetCore.Mvc;
using NotificationService.APIs;
using NotificationService.APIs.Common;
using NotificationService.APIs.Dtos;
using NotificationService.APIs.Errors;

namespace NotificationService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class NotificationSettingsControllerBase : ControllerBase
{
    protected readonly INotificationSettingsService _service;

    public NotificationSettingsControllerBase(INotificationSettingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one NotificationSetting
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<NotificationSetting>> CreateNotificationSetting(
        NotificationSettingCreateInput input
    )
    {
        var notificationSetting = await _service.CreateNotificationSetting(input);

        return CreatedAtAction(
            nameof(NotificationSetting),
            new { id = notificationSetting.Id },
            notificationSetting
        );
    }

    /// <summary>
    /// Delete one NotificationSetting
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteNotificationSetting(
        [FromRoute()] NotificationSettingWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteNotificationSetting(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many NotificationSettings
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<NotificationSetting>>> NotificationSettings(
        [FromQuery()] NotificationSettingFindManyArgs filter
    )
    {
        return Ok(await _service.NotificationSettings(filter));
    }

    /// <summary>
    /// Meta data about NotificationSetting records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> NotificationSettingsMeta(
        [FromQuery()] NotificationSettingFindManyArgs filter
    )
    {
        return Ok(await _service.NotificationSettingsMeta(filter));
    }

    /// <summary>
    /// Get one NotificationSetting
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<NotificationSetting>> NotificationSetting(
        [FromRoute()] NotificationSettingWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.NotificationSetting(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one NotificationSetting
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateNotificationSetting(
        [FromRoute()] NotificationSettingWhereUniqueInput uniqueId,
        [FromQuery()] NotificationSettingUpdateInput notificationSettingUpdateDto
    )
    {
        try
        {
            await _service.UpdateNotificationSetting(uniqueId, notificationSettingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
