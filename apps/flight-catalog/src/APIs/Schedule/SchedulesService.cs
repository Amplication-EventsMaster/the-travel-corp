using FlightCatalog.Infrastructure;

namespace FlightCatalog.APIs;

public class SchedulesService : SchedulesServiceBase
{
    public SchedulesService(FlightCatalogDbContext context)
        : base(context) { }
}
