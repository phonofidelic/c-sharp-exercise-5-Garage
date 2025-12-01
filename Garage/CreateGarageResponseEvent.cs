using Garage.Library;

namespace Garage
{
    internal class CreateGarageResponseEvent : ApplicationEvent
    {
        public CreateGarageResponseDTO Payload { get; private init; }
        public CreateGarageResponseEvent(CreateGarageResponseDTO responseDTO)
        {
            Payload = responseDTO;
        }
    }
}