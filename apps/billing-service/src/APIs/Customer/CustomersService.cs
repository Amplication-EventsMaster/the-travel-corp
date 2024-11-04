using BillingService.Infrastructure;

namespace BillingService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(BillingServiceDbContext context)
        : base(context) { }
}
