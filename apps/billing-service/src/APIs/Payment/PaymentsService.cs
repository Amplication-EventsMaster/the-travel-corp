using BillingService.Infrastructure;

namespace BillingService.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(BillingServiceDbContext context)
        : base(context) { }
}
