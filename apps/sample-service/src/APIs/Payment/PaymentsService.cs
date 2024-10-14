using SampleService.Infrastructure;

namespace SampleService.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(SampleServiceDbContext context)
        : base(context) { }
}
