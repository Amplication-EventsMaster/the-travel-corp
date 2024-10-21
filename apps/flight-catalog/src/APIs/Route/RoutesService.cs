using FlightCatalog.Infrastructure;

namespace FlightCatalog.APIs;

public class RoutesService : RoutesServiceBase
{
    public RoutesService(FlightCatalogDbContext context)
        : base(context) { }
}
