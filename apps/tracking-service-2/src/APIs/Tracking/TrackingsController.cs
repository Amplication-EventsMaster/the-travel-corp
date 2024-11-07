using Microsoft.AspNetCore.Mvc;

namespace TrackingService_2.APIs;

[ApiController()]
public class TrackingsController : TrackingsControllerBase
{
    public TrackingsController(ITrackingsService service)
        : base(service) { }
}
