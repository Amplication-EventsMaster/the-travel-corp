using Microsoft.AspNetCore.Mvc;
using SampleService.APIs;
using SampleService.APIs.Common;
using SampleService.APIs.Dtos;
using SampleService.APIs.Errors;

namespace SampleService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FeedbacksControllerBase : ControllerBase
{
    protected readonly IFeedbacksService _service;

    public FeedbacksControllerBase(IFeedbacksService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one feedback
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Feedback>> CreateFeedback(FeedbackCreateInput input)
    {
        var feedback = await _service.CreateFeedback(input);

        return CreatedAtAction(nameof(Feedback), new { id = feedback.Id }, feedback);
    }

    /// <summary>
    /// Delete one feedback
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFeedback([FromRoute()] FeedbackWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFeedback(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many feedbacks
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Feedback>>> Feedbacks(
        [FromQuery()] FeedbackFindManyArgs filter
    )
    {
        return Ok(await _service.Feedbacks(filter));
    }

    /// <summary>
    /// Meta data about feedback records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FeedbacksMeta(
        [FromQuery()] FeedbackFindManyArgs filter
    )
    {
        return Ok(await _service.FeedbacksMeta(filter));
    }

    /// <summary>
    /// Get one feedback
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Feedback>> Feedback(
        [FromRoute()] FeedbackWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Feedback(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one feedback
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFeedback(
        [FromRoute()] FeedbackWhereUniqueInput uniqueId,
        [FromQuery()] FeedbackUpdateInput feedbackUpdateDto
    )
    {
        try
        {
            await _service.UpdateFeedback(uniqueId, feedbackUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a order record for feedback
    /// </summary>
    [HttpGet("{Id}/order")]
    public async Task<ActionResult<List<Order>>> GetOrder(
        [FromRoute()] FeedbackWhereUniqueInput uniqueId
    )
    {
        var order = await _service.GetOrder(uniqueId);
        return Ok(order);
    }
}
