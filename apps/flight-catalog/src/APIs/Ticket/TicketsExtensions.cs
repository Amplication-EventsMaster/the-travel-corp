using FlightCatalog.APIs.Dtos;
using FlightCatalog.Infrastructure.Models;

namespace FlightCatalog.APIs.Extensions;

public static class TicketsExtensions
{
    public static Ticket ToDto(this TicketDbModel model)
    {
        return new Ticket
        {
            CreatedAt = model.CreatedAt,
            Flight = model.FlightId,
            Id = model.Id,
            Price = model.Price,
            SeatNumber = model.SeatNumber,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TicketDbModel ToModel(
        this TicketUpdateInput updateDto,
        TicketWhereUniqueInput uniqueId
    )
    {
        var ticket = new TicketDbModel
        {
            Id = uniqueId.Id,
            Price = updateDto.Price,
            SeatNumber = updateDto.SeatNumber
        };

        if (updateDto.CreatedAt != null)
        {
            ticket.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Flight != null)
        {
            ticket.FlightId = updateDto.Flight;
        }
        if (updateDto.UpdatedAt != null)
        {
            ticket.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return ticket;
    }
}
