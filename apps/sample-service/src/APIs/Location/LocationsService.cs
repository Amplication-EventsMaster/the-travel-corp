using SampleService.Infrastructure;

namespace SampleService.APIs;

public class LocationsService : LocationsServiceBase
{
    public LocationsService(SampleServiceDbContext context)
        : base(context) { }
}
