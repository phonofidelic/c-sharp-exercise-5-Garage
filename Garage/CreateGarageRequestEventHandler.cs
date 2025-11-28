using Garage.Library;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class CreateGarageRequestEventHandler(ILogger<CreateGarageRequestEventHandler> logger) 
        : ApplicationEventHandler<CreateGarageRequestEvent>
    {
        protected override void _handle(CreateGarageRequestEvent @event)
        {
            logger.LogInformation("Handling event: {Event}", @event);
        }

        public override void SetNext(IHandler<CreateGarageRequestEvent> handler)
        {
            throw new NotImplementedException();
        }
    }
}
