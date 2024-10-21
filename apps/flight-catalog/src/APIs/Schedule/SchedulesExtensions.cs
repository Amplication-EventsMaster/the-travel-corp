using FlightCatalog.APIs.Dtos;
using FlightCatalog.Infrastructure.Models;

namespace FlightCatalog.APIs.Extensions;

public static class SchedulesExtensions
{
    public static Schedule ToDto(this ScheduleDbModel model)
    {
        return new Schedule
        {
            Airport = model.AirportId,
            CreatedAt = model.CreatedAt,
            Day = model.Day,
            Flight = model.FlightId,
            Id = model.Id,
            Time = model.Time,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ScheduleDbModel ToModel(
        this ScheduleUpdateInput updateDto,
        ScheduleWhereUniqueInput uniqueId
    )
    {
        var schedule = new ScheduleDbModel
        {
            Id = uniqueId.Id,
            Day = updateDto.Day,
            Time = updateDto.Time
        };

        if (updateDto.Airport != null)
        {
            schedule.AirportId = updateDto.Airport;
        }
        if (updateDto.CreatedAt != null)
        {
            schedule.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Flight != null)
        {
            schedule.FlightId = updateDto.Flight;
        }
        if (updateDto.UpdatedAt != null)
        {
            schedule.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return schedule;
    }
}
