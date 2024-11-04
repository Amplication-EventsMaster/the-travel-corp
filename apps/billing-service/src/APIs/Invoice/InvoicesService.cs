using BillingService.Infrastructure;

namespace BillingService.APIs;

public class InvoicesService : InvoicesServiceBase
{
    public InvoicesService(BillingServiceDbContext context)
        : base(context) { }
}
