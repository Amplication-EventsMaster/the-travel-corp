using TrackingService_2.Infrastructure;

namespace TrackingService_2.APIs;

public class TrackingsService : TrackingsServiceBase
{
    public TrackingsService(TrackingService_2DbContext context)
        : base(context) { }
}
