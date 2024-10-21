using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[ApiController()]
public class RoutesController : RoutesControllerBase
{
    public RoutesController(IRoutesService service)
        : base(service) { }
}
