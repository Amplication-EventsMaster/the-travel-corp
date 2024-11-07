using Microsoft.AspNetCore.Mvc;
using TrackingService_2.APIs;
using TrackingService_2.APIs.Common;
using TrackingService_2.APIs.Dtos;
using TrackingService_2.APIs.Errors;

namespace TrackingService_2.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TrackingsControllerBase : ControllerBase
{
    protected readonly ITrackingsService _service;

    public TrackingsControllerBase(ITrackingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one tracking
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Tracking>> CreateTracking(TrackingCreateInput input)
    {
        var tracking = await _service.CreateTracking(input);

        return CreatedAtAction(nameof(Tracking), new { id = tracking.Id }, tracking);
    }

    /// <summary>
    /// Delete one tracking
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTracking([FromRoute()] TrackingWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTracking(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many trackings
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Tracking>>> Trackings(
        [FromQuery()] TrackingFindManyArgs filter
    )
    {
        return Ok(await _service.Trackings(filter));
    }

    /// <summary>
    /// Meta data about tracking records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TrackingsMeta(
        [FromQuery()] TrackingFindManyArgs filter
    )
    {
        return Ok(await _service.TrackingsMeta(filter));
    }

    /// <summary>
    /// Get one tracking
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Tracking>> Tracking(
        [FromRoute()] TrackingWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Tracking(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one tracking
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTracking(
        [FromRoute()] TrackingWhereUniqueInput uniqueId,
        [FromQuery()] TrackingUpdateInput trackingUpdateDto
    )
    {
        try
        {
            await _service.UpdateTracking(uniqueId, trackingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Customer record for tracking
    /// </summary>
    [HttpGet("{Id}/customer")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] TrackingWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }
}
