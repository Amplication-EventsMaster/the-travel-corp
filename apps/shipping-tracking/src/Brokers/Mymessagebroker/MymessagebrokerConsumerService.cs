using Microsoft.Extensions.DependencyInjection;
using ShippingTracking.Brokers.Infrastructure;
using ShippingTracking.Brokers.Mymessagebroker;

namespace ShippingTracking.Brokers.Mymessagebroker;

public class MymessagebrokerConsumerService
    : KafkaConsumerService<MymessagebrokerMessageHandlersController>
{
    public MymessagebrokerConsumerService(
        IServiceScopeFactory serviceScopeFactory,
        KafkaOptions kafkaOptions
    )
        : base(serviceScopeFactory, kafkaOptions) { }
}
