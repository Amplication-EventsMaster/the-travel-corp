using Microsoft.AspNetCore.Mvc;
using TrackingService_2.APIs;
using TrackingService_2.APIs.Common;
using TrackingService_2.APIs.Dtos;
using TrackingService_2.APIs.Errors;

namespace TrackingService_2.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CustomersControllerBase : ControllerBase
{
    protected readonly ICustomersService _service;

    public CustomersControllerBase(ICustomersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one customer
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Customer>> CreateCustomer(CustomerCreateInput input)
    {
        var customer = await _service.CreateCustomer(input);

        return CreatedAtAction(nameof(Customer), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Delete one customer
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCustomer([FromRoute()] CustomerWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCustomer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many customers
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Customer>>> Customers(
        [FromQuery()] CustomerFindManyArgs filter
    )
    {
        return Ok(await _service.Customers(filter));
    }

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CustomersMeta(
        [FromQuery()] CustomerFindManyArgs filter
    )
    {
        return Ok(await _service.CustomersMeta(filter));
    }

    /// <summary>
    /// Get one customer
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Customer>> Customer(
        [FromRoute()] CustomerWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Customer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one customer
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCustomer(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] CustomerUpdateInput customerUpdateDto
    )
    {
        try
        {
            await _service.UpdateCustomer(uniqueId, customerUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple trackings records to customer
    /// </summary>
    [HttpPost("{Id}/trackings")]
    public async Task<ActionResult> ConnectTrackings(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] TrackingWhereUniqueInput[] trackingsId
    )
    {
        try
        {
            await _service.ConnectTrackings(uniqueId, trackingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple trackings records from customer
    /// </summary>
    [HttpDelete("{Id}/trackings")]
    public async Task<ActionResult> DisconnectTrackings(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromBody()] TrackingWhereUniqueInput[] trackingsId
    )
    {
        try
        {
            await _service.DisconnectTrackings(uniqueId, trackingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple trackings records for customer
    /// </summary>
    [HttpGet("{Id}/trackings")]
    public async Task<ActionResult<List<Tracking>>> FindTrackings(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] TrackingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindTrackings(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple trackings records for customer
    /// </summary>
    [HttpPatch("{Id}/trackings")]
    public async Task<ActionResult> UpdateTrackings(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromBody()] TrackingWhereUniqueInput[] trackingsId
    )
    {
        try
        {
            await _service.UpdateTrackings(uniqueId, trackingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
