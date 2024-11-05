using BillingService.Infrastructure;

namespace BillingService.APIs;

public class FeedbacksService : FeedbacksServiceBase
{
    public FeedbacksService(BillingServiceDbContext context)
        : base(context) { }
}
