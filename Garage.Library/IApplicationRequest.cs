namespace Garage.Library
{
    public interface IApplicationRequest
    {
        public Task Publish(ApplicationEvent appEvent, CancellationToken stoppingToken);
    }
}