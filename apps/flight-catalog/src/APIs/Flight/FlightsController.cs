using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[ApiController()]
public class FlightsController : FlightsControllerBase
{
    public FlightsController(IFlightsService service)
        : base(service) { }
}
