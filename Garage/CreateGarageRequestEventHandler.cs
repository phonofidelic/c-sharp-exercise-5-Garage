using Garage.Library;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class CreateGarageRequestEventHandler(
        IApplicationRequest request, 
        ILogger<CreateGarageRequestEventHandler> logger) 
        : ApplicationEventHandler<CreateGarageRequestEvent>(logger)
    {
        protected override void _handle<TEvent>(TEvent @event)
        {
            logger.LogInformation("Handling event: {Event}", @event);
            logger.LogInformation("Payload: {Payload}", @event.Payload);
            CreateGarageRequestDTO parsedPayload = (CreateGarageRequestDTO)@event.Payload;
            var (name, capacity) = parsedPayload;
            // Fake list of vehicle IDs
            List<Guid> vehicles = [
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                ];

            CancellationToken stoppingToken = new();
            _ = request.Publish(
                new CreateGarageResponseEvent(new CreateGarageResponseDTO(name, capacity, vehicles)),
                stoppingToken);
        }

        public override void SetNext(IHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}
