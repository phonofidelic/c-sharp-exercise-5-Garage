
namespace Garage.Library
{
    public class EventBus(MessageQueue queue) : IEventBus
    {
        public async Task PublishAsync(
            ApplicationEvent applicationEvent,
            CancellationToken cancellationToken)
        {
            await queue.Writer.WriteAsync(applicationEvent, cancellationToken);
        }
    }
}