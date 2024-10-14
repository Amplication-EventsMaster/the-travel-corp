using SampleService.Infrastructure;

namespace SampleService.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(SampleServiceDbContext context)
        : base(context) { }
}
