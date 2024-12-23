using BillingService.APIs.Common;
using BillingService.APIs.Dtos;

namespace BillingService.APIs;

public interface IInvoicesService
{
    /// <summary>
    /// Create one Invoice
    /// </summary>
    public Task<Invoice> CreateInvoice(InvoiceCreateInput invoice);

    /// <summary>
    /// Delete one Invoice
    /// </summary>
    public Task DeleteInvoice(InvoiceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Invoices
    /// </summary>
    public Task<List<Invoice>> Invoices(InvoiceFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Invoice records
    /// </summary>
    public Task<MetadataDto> InvoicesMeta(InvoiceFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Invoice
    /// </summary>
    public Task<Invoice> Invoice(InvoiceWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Invoice
    /// </summary>
    public Task UpdateInvoice(InvoiceWhereUniqueInput uniqueId, InvoiceUpdateInput updateDto);

    /// <summary>
    /// Get a Customer record for Invoice
    /// </summary>
    public Task<Customer> GetCustomer(InvoiceWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Payments records to Invoice
    /// </summary>
    public Task ConnectPayments(
        InvoiceWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple Payments records from Invoice
    /// </summary>
    public Task DisconnectPayments(
        InvoiceWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Find multiple Payments records for Invoice
    /// </summary>
    public Task<List<Payment>> FindPayments(
        InvoiceWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple Payments records for Invoice
    /// </summary>
    public Task UpdatePayments(
        InvoiceWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );
}
