//using Garage.Library;
using Garage.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class ApplicationEventProcessorJob(
        MessageQueue queue,
        IGarageAPI api,
        ILogger<ApplicationEventProcessorJob> logger)
        : BackgroundService
    {
        public IGarageAPI _api { get; } = api;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (ApplicationEvent<Enum> applicationEvent in queue.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    logger.LogInformation("Processing message\n\tEvent: {Event}\tId: {Id}\tRecord: {Record}", applicationEvent, applicationEvent.Id ,applicationEvent.Payload);
                    // Route request to the appropriate handler?
                    ProcessEvent(applicationEvent);
                    await Task.Delay(100, stoppingToken);
                }
                catch (Exception ex) {
                    logger.LogError(
                        ex,
                        "Could not publish event with Id {ApplicationEvent}", applicationEvent);
                }
            }
        }

        private void ProcessEvent(ApplicationEvent<Enum> applicationEvent)
        {
            _api.ProcessRequest(applicationEvent.Type);
            //throw new NotImplementedException();
        }
    }
}