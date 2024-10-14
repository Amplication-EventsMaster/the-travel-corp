using SampleService.APIs.Dtos;
using SampleService.Infrastructure.Models;

namespace SampleService.APIs.Extensions;

public static class OrdersExtensions
{
    public static Order ToDto(this OrderDbModel model)
    {
        return new Order
        {
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            Feedbacks = model.Feedbacks?.Select(x => x.Id).ToList(),
            Id = model.Id,
            OrderDate = model.OrderDate,
            Payments = model.Payments?.Select(x => x.Id).ToList(),
            Status = model.Status,
            TotalAmount = model.TotalAmount,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OrderDbModel ToModel(
        this OrderUpdateInput updateDto,
        OrderWhereUniqueInput uniqueId
    )
    {
        var order = new OrderDbModel
        {
            Id = uniqueId.Id,
            OrderDate = updateDto.OrderDate,
            Status = updateDto.Status,
            TotalAmount = updateDto.TotalAmount
        };

        if (updateDto.CreatedAt != null)
        {
            order.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            order.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            order.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return order;
    }
}
