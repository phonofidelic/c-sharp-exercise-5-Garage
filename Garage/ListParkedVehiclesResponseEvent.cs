using Garage.Library;

namespace Garage
{
    internal class ListParkedVehiclesResponseEvent : ApplicationEvent
    {
        public ListParkedVehiclesResponseEvent(ListParkedVehiclesResponseDTO responseDTO)
        {
            Payload = responseDTO;
        }
    }
}

