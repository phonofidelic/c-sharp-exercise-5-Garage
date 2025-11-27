//using Garage.Library;
//using Garage.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Garage.Library
{
    public class ApplicationEventProcessorJob(
        MessageQueue queue,
        IAPI api,
        ILogger<ApplicationEventProcessorJob> logger)
        : BackgroundService
    {
        public IAPI _api { get; } = api;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (ApplicationEvent applicationEvent in queue.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    logger.LogInformation("Processing message\n\tEvent: {Event}\tId: {Id}\tRecord: {Record}", applicationEvent, applicationEvent.Id, applicationEvent.Payload);
                    // Route request to the appropriate handler?
                    _api.ProcessRequest(applicationEvent);
                    await Task.Delay(100, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(
                        ex,
                        "Could not publish event with Id {ApplicationEvent}", applicationEvent);
                }
            }
        }
    }
}