using Garage.Library;
using Garage.UI;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class ListParkedVehiclesRequestEventHandler(
        Garage<Vehicle> garage,
        ListVehiclesMenu listParkedVehiclesMenu,
        ILogger<ListParkedVehiclesRequestEventHandler> logger)
        : ApplicationEventHandler<ListParkedVehiclesRequestEvent>(logger)
    {
        public ListParkedVehiclesDTO? Props { get; private set; } = null;
        protected override void _handle<TEvent>(TEvent @event)
        {
            logger.LogInformation("Processing data for event: {Event}", @event);
            ListParkedVehiclesDTO parsedPayload = (ListParkedVehiclesDTO)@event.Payload;
            Props = parsedPayload;
            logger.LogInformation("Props set: {}", Props);

            Queue<Vehicle>? vehicles = garage.GetAll();

            // Reset the menu items list
            listParkedVehiclesMenu.ResetMenuItems();

            ConsoleUI.WriteLine("Showing all parked vehicles:");
            // Add menu items to the list
            for (int i = 0; i < garage.Count; i++)
            {
                Vehicle vehicle = vehicles.Dequeue();
                if (vehicle != null)
                    listParkedVehiclesMenu.AddMenuItem(new MenuItemDTO(
                        name: $"Make: {vehicle.Props.Make}\tColor: {vehicle.Props.Color}\t Type: {vehicle.Props.Type}"));
            }
            // Render the list
            listParkedVehiclesMenu.Render();
        }

        public override void SetNext(IHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}
