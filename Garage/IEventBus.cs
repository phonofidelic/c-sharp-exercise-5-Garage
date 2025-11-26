namespace Garage
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T applicationEvent, CancellationToken cancellationToken = default)
            where T : class, IApplicationEvent;
    }
}