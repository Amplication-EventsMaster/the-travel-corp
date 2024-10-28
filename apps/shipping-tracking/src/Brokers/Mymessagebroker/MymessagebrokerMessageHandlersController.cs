using System.Threading.Tasks;
using ShippingTracking.Brokers.Infrastructure;

namespace ShippingTracking.Brokers.Mymessagebroker;

public class MymessagebrokerMessageHandlersController
{
    [Topic("topic.sample.v1")]
    public Task HandleTopicSampleV1(string message)
    {
        //set your message handling logic here

        return Task.CompletedTask;
    }
}
