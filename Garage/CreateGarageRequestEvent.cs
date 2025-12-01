
using Garage.Library;

namespace Garage
{
    internal class CreateGarageRequestEvent : ApplicationEvent
    {
        public CreateGarageRequestDTO Payload { get; private init; }
        public CreateGarageRequestEvent(CreateGarageRequestDTO garageCreateRequestData)
        {
            Payload = garageCreateRequestData;
        }
    }
}