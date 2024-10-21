using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[ApiController()]
public class TicketsController : TicketsControllerBase
{
    public TicketsController(ITicketsService service)
        : base(service) { }
}
