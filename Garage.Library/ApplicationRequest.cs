using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public class ApplicationRequest(IEventBus eventBus) : IApplicationRequest
    {
        private IEventBus _eventBus = eventBus;

        public Task Publish(ApplicationEvent appEvent, CancellationToken stoppingToken)
        {
            //CancellationToken stoppingToken = new();
            return _eventBus.PublishAsync(appEvent, stoppingToken);
        }
    }
}
