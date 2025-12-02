using Garage.Library;
using Garage.UI;

namespace Garage
{
    internal class ListVehiclesView(
        IApplicationRequest request) 
        : IRender
    {
        public void Render()
        {
            bool result = request.TryPublish(new ListParkedVehiclesRequestEvent(
               new ListParkedVehiclesDTO([])));

            if (!result)
                throw new Exception("Could not publish event");
        }
    }
}
