
namespace Garage
{
    internal class EventBus(MessageQueue queue) : IEventBus
    {
        public async Task PublishAsync<T>(
            T applicationEvent, 
            CancellationToken cancellationToken)
            where T : class, IApplicationEvent
        {
            await queue.Writer.WriteAsync(applicationEvent, cancellationToken);
        }
    }
}