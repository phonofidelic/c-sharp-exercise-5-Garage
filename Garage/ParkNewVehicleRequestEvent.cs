using Garage.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class ParkNewVehicleRequestEvent : ApplicationEvent
    {
        public ParkNewVehicleRequestEvent(ParkNewVehicleRequestDTO parkVehicleRequestData)
        {
            Payload = parkVehicleRequestData;
        }
    }
}
