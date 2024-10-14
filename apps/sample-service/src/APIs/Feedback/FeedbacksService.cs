using SampleService.Infrastructure;

namespace SampleService.APIs;

public class FeedbacksService : FeedbacksServiceBase
{
    public FeedbacksService(SampleServiceDbContext context)
        : base(context) { }
}
