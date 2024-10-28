using ShippingTracking.Infrastructure;

namespace ShippingTracking.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(ShippingTrackingDbContext context)
        : base(context) { }
}
