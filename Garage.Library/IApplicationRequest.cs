namespace Garage.Library
{
    public interface IApplicationRequest
    {
        public Task PublishAsync(ApplicationEvent appEvent, CancellationToken stoppingToken);
    }
}