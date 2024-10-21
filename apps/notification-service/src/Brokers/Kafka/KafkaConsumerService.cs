using Microsoft.Extensions.DependencyInjection;
using NotificationService.Brokers.Infrastructure;
using NotificationService.Brokers.Kafka;

namespace NotificationService.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
