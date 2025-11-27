using Garage.Library;

namespace Garage
{
    internal class CreateGarageResponseEvent : ApplicationEvent
    {
        public CreateGarageResponseEvent(CreateGarageResponseDTO responseDTO)
            : base(GarageRequestType.GarageCreate)
        {
            Payload = responseDTO;
        }
    }
}