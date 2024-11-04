using BillingService.APIs.Dtos;
using BillingService.Infrastructure.Models;

namespace BillingService.APIs.Extensions;

public static class InvoicesExtensions
{
    public static Invoice ToDto(this InvoiceDbModel model)
    {
        return new Invoice
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            Date = model.Date,
            Id = model.Id,
            Payments = model.Payments?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static InvoiceDbModel ToModel(
        this InvoiceUpdateInput updateDto,
        InvoiceWhereUniqueInput uniqueId
    )
    {
        var invoice = new InvoiceDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Date = updateDto.Date
        };

        if (updateDto.CreatedAt != null)
        {
            invoice.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            invoice.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            invoice.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return invoice;
    }
}
