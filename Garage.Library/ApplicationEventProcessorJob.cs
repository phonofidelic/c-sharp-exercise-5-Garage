using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Garage.Library
{
    public class ApplicationEventProcessorJob(
        MessageQueue queue,
        IApplicationManager manager,
        ILogger<ApplicationEventProcessorJob> logger)
        : BackgroundService
    {
        private IApplicationManager _manager { get; } = manager;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (ApplicationEvent applicationEvent in queue.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    logger.LogInformation("Processing message\n\tEvent: {Event}\tId: {Id}\tRecord: {Record}", applicationEvent, applicationEvent.Id, applicationEvent.Payload);
                    // Send the event to registered handlers
                    _manager.Handle(applicationEvent);
                    
                    // ToDo: remove mock async delay
                    await Task.Delay(100, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(
                        ex,
                        "Could not publish event with Id {ApplicationEvent}", applicationEvent.Id);
                }
            }
        }
    }
}