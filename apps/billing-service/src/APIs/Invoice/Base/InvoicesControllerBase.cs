using BillingService.APIs;
using BillingService.APIs.Common;
using BillingService.APIs.Dtos;
using BillingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BillingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class InvoicesControllerBase : ControllerBase
{
    protected readonly IInvoicesService _service;

    public InvoicesControllerBase(IInvoicesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Invoice
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Invoice>> CreateInvoice(InvoiceCreateInput input)
    {
        var invoice = await _service.CreateInvoice(input);

        return CreatedAtAction(nameof(Invoice), new { id = invoice.Id }, invoice);
    }

    /// <summary>
    /// Delete one Invoice
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteInvoice([FromRoute()] InvoiceWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteInvoice(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Invoices
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Invoice>>> Invoices(
        [FromQuery()] InvoiceFindManyArgs filter
    )
    {
        return Ok(await _service.Invoices(filter));
    }

    /// <summary>
    /// Meta data about Invoice records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> InvoicesMeta(
        [FromQuery()] InvoiceFindManyArgs filter
    )
    {
        return Ok(await _service.InvoicesMeta(filter));
    }

    /// <summary>
    /// Get one Invoice
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Invoice>> Invoice([FromRoute()] InvoiceWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Invoice(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Invoice
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateInvoice(
        [FromRoute()] InvoiceWhereUniqueInput uniqueId,
        [FromQuery()] InvoiceUpdateInput invoiceUpdateDto
    )
    {
        try
        {
            await _service.UpdateInvoice(uniqueId, invoiceUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Customer record for Invoice
    /// </summary>
    [HttpGet("{Id}/customer")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] InvoiceWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }

    /// <summary>
    /// Connect multiple Payments records to Invoice
    /// </summary>
    [HttpPost("{Id}/payments")]
    public async Task<ActionResult> ConnectPayments(
        [FromRoute()] InvoiceWhereUniqueInput uniqueId,
        [FromQuery()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.ConnectPayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Payments records from Invoice
    /// </summary>
    [HttpDelete("{Id}/payments")]
    public async Task<ActionResult> DisconnectPayments(
        [FromRoute()] InvoiceWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.DisconnectPayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Payments records for Invoice
    /// </summary>
    [HttpGet("{Id}/payments")]
    public async Task<ActionResult<List<Payment>>> FindPayments(
        [FromRoute()] InvoiceWhereUniqueInput uniqueId,
        [FromQuery()] PaymentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayments(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Payments records for Invoice
    /// </summary>
    [HttpPatch("{Id}/payments")]
    public async Task<ActionResult> UpdatePayments(
        [FromRoute()] InvoiceWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.UpdatePayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
