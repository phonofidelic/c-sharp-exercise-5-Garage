using Garage.Library;

namespace Garage
{
    public interface IEventBus
    {
        Task PublishAsync<T>(ApplicationEvent<T> applicationEvent, CancellationToken cancellationToken = default)
            where T : Enum;
    }
}