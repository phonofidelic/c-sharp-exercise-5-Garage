using Garage.Library;

namespace Garage
{
    internal class CreateGarageResponseEvent : ApplicationEvent
    {
        public CreateGarageResponseEvent(CreateGarageResponseDTO responseDTO)
        {
            Payload = responseDTO;
        }
    }
}