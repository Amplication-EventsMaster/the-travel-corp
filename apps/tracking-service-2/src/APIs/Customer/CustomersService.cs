using TrackingService_2.Infrastructure;

namespace TrackingService_2.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(TrackingService_2DbContext context)
        : base(context) { }
}
