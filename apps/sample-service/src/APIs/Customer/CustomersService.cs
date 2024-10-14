using SampleService.Infrastructure;

namespace SampleService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(SampleServiceDbContext context)
        : base(context) { }
}
