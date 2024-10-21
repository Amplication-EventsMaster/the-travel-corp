using FlightCatalog.Infrastructure;

namespace FlightCatalog.APIs;

public class FlightsService : FlightsServiceBase
{
    public FlightsService(FlightCatalogDbContext context)
        : base(context) { }
}
