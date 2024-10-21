using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[ApiController()]
public class AirlinesController : AirlinesControllerBase
{
    public AirlinesController(IAirlinesService service)
        : base(service) { }
}
