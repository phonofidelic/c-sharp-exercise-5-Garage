
namespace Garage
{
    internal class EventBus(MessageQueue queue) : IEventBus
    {
        public async Task PublishAsync<T>(
            ApplicationEvent<T> applicationEvent, 
            CancellationToken cancellationToken)
            where T : Enum
        {
            await queue.Writer.WriteAsync(applicationEvent, cancellationToken);
        }
    }
}