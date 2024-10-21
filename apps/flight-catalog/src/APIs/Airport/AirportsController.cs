using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[ApiController()]
public class AirportsController : AirportsControllerBase
{
    public AirportsController(IAirportsService service)
        : base(service) { }
}
