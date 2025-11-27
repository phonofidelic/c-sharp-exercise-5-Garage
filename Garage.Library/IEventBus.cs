using Garage.Library;

namespace Garage.Library
{
    public interface IEventBus
    {
        Task PublishAsync(
            ApplicationEvent applicationEvent, 
            CancellationToken cancellationToken = default);
    }
}