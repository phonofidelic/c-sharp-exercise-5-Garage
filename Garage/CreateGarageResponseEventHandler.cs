using Garage.Library;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class CreateGarageResponseEventHandler(ILogger<CreateGarageResponseEventHandler> logger)
        : ApplicationEventHandler<CreateGarageResponseEvent>
    {
        protected override void _handle(CreateGarageResponseEvent @event)
        {
            logger.LogInformation("Handling event: {Event}", @event);
        }
        public override void SetNext(IHandler<CreateGarageResponseEvent> handler)
        {
            throw new NotImplementedException();
        }
    }
}