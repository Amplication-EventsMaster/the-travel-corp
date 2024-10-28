using ShippingTracking.Brokers.Infrastructure;

namespace ShippingTracking.Brokers.Mymessagebroker;

public class MymessagebrokerProducerService : InternalProducer
{
    public MymessagebrokerProducerService(string bootstrapServers)
        : base(bootstrapServers) { }
}
