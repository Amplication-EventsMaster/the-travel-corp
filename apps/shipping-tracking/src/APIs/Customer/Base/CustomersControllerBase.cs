using Microsoft.AspNetCore.Mvc;
using ShippingTracking.APIs;
using ShippingTracking.APIs.Common;
using ShippingTracking.APIs.Dtos;
using ShippingTracking.APIs.Errors;

namespace ShippingTracking.APIs;

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
}
