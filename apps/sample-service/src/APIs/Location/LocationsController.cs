using Microsoft.AspNetCore.Mvc;

namespace SampleService.APIs;

[ApiController()]
public class LocationsController : LocationsControllerBase
{
    public LocationsController(ILocationsService service)
        : base(service) { }
}
