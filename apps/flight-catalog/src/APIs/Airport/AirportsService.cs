using FlightCatalog.Infrastructure;

namespace FlightCatalog.APIs;

public class AirportsService : AirportsServiceBase
{
    public AirportsService(FlightCatalogDbContext context)
        : base(context) { }
}
