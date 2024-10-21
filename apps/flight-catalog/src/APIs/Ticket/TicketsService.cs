using FlightCatalog.Infrastructure;

namespace FlightCatalog.APIs;

public class TicketsService : TicketsServiceBase
{
    public TicketsService(FlightCatalogDbContext context)
        : base(context) { }
}
