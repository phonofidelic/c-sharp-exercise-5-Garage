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

        public Task PublishAsync(ApplicationEvent appEvent, CancellationToken stoppingToken)
        {
            return _eventBus.PublishAsync(appEvent, stoppingToken);
        }

        public bool TryPublish(ApplicationEvent appEvent)
        {
            return _eventBus.TryPublish(appEvent);
        }
    }
}
