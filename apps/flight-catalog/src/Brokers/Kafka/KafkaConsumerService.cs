using FlightCatalog.Brokers.Infrastructure;
using FlightCatalog.Brokers.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace FlightCatalog.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
