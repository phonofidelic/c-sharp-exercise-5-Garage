using Garage.Library;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class ParkNewVehicleRequestEventHandler(
        Garage<Vehicle> garage,
        //IParkable vehicle,
        IApplicationRequest request,
        ILogger<ParkNewVehicleRequestEventHandler> logger) 
        : ApplicationEventHandler<ParkNewVehicleRequestEvent>(logger)
    {
        protected override void _handle<TEvent>(TEvent @event)
        {
            logger.LogInformation("Handling event: {Event}", @event);
            logger.LogInformation("Payload: {Payload}", @event.Payload);
            ParkNewVehicleRequestDTO parsedPayload = (ParkNewVehicleRequestDTO)@event.Payload;
            //var (Make, VIN, Color, Type) = parsedPayload;

            //vehicle.Park<ParkNewVehicleRequestDTO>(parsedPayload);
            garage.Park(parsedPayload);
        }

        public override void SetNext(IHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}
