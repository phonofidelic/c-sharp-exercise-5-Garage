using Garage.Library;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageAPI(IEventBus eventBus, ILogger<GarageAPI> logger) : Application("Garage API", eventBus), IAPI
    {
        public override ApplicationStatus Run()
        {
            logger.LogInformation("Running {Name}", Name);
            return new(1);
        }

        public ApplicationEvent RouteEvent(ApplicationEvent @event)
        {
            ApplicationEvent response;
            switch (@event.Type)
            {
                case GarageRequestType.GarageCreate:
                    // ToDo: Handle event
                    logger.LogInformation("Routing event: {Event}", @event.Type);
                    // Process incoming data to create a new Garage instance.
                    // ToDo: Parse and validate the event Payload
                    CreateGarageRequestDTO parsedPayload = (CreateGarageRequestDTO)@event.Payload;

                    var (name, capacity) = parsedPayload;
                    // Fake list of vehicle IDs
                    List<Guid> vehicles = [
                        Guid.NewGuid(),
                        Guid.NewGuid(),
                        Guid.NewGuid(),
                        ];
                    response = new CreateGarageResponseEvent(new(name, capacity, vehicles));
                    return response;
                    
                default:
                    return new NotFoundResponseEvent();
            }
            
        }
    }

    record NotFoundResponseDTO(string Message);
    public class NotFoundResponseEvent: ApplicationEvent
    {
        public NotFoundResponseEvent()
            : base(GarageRequestType.NotFound)
        {
            Payload = new NotFoundResponseDTO("Resource not found");
        }
    }

    public enum GarageRequestType
    {
        NotFound,
        GarageCreate
    }
}

