
using Garage.Library;

namespace Garage
{
    internal class CreateGarageRequestEvent : ApplicationEvent
    {
        public CreateGarageRequestEvent(CreateGarageRequestDTO garageCreateRequestData)
        {
            Payload = garageCreateRequestData;
        }
    }
}