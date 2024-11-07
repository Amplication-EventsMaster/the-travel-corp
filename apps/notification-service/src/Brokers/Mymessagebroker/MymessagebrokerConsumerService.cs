using Microsoft.Extensions.DependencyInjection;
using NotificationService.Brokers.Infrastructure;
using NotificationService.Brokers.Mymessagebroker;

namespace NotificationService.Brokers.Mymessagebroker;

public class MymessagebrokerConsumerService
    : KafkaConsumerService<MymessagebrokerMessageHandlersController>
{
    public MymessagebrokerConsumerService(
        IServiceScopeFactory serviceScopeFactory,
        KafkaOptions kafkaOptions
    )
        : base(serviceScopeFactory, kafkaOptions) { }
}
