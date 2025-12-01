using Garage.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class ListParkedVehiclesRequestEvent : ApplicationEvent
    {
        public ListParkedVehiclesRequestEvent(ListParkedVehiclesDTO listParkedVehiclesRequestData)
        {
            Payload = listParkedVehiclesRequestData;
        }
    }
}
