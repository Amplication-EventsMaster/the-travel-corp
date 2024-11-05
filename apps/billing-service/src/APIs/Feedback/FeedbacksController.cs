using Microsoft.AspNetCore.Mvc;

namespace BillingService.APIs;

[ApiController()]
public class FeedbacksController : FeedbacksControllerBase
{
    public FeedbacksController(IFeedbacksService service)
        : base(service) { }
}
