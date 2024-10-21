using FlightCatalog.Infrastructure;

namespace FlightCatalog.APIs;

public class AirlinesService : AirlinesServiceBase
{
    public AirlinesService(FlightCatalogDbContext context)
        : base(context) { }
}
