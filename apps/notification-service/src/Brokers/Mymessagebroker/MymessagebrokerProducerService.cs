using NotificationService.Brokers.Infrastructure;

namespace NotificationService.Brokers.Mymessagebroker;

public class MymessagebrokerProducerService : InternalProducer
{
    public MymessagebrokerProducerService(string bootstrapServers)
        : base(bootstrapServers) { }
}
