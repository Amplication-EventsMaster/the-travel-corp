using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs;

[ApiController()]
public class SchedulesController : SchedulesControllerBase
{
    public SchedulesController(ISchedulesService service)
        : base(service) { }
}
