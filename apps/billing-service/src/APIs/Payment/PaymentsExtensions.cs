using BillingService.APIs.Dtos;
using BillingService.Infrastructure.Models;

namespace BillingService.APIs.Extensions;

public static class PaymentsExtensions
{
    public static Payment ToDto(this PaymentDbModel model)
    {
        return new Payment
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            Id = model.Id,
            Invoice = model.InvoiceId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PaymentDbModel ToModel(
        this PaymentUpdateInput updateDto,
        PaymentWhereUniqueInput uniqueId
    )
    {
        var payment = new PaymentDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Date = updateDto.Date
        };

        if (updateDto.CreatedAt != null)
        {
            payment.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Invoice != null)
        {
            payment.InvoiceId = updateDto.Invoice;
        }
        if (updateDto.UpdatedAt != null)
        {
            payment.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return payment;
    }
}
