
using Garage.Library;

namespace Garage
{
    internal class CreateGarageRequestEvent : ApplicationEvent
    {
        public CreateGarageRequestEvent(CreateGarageRequestDTO garageCreate)
        {
            Payload = garageCreate;
        }
    }
}