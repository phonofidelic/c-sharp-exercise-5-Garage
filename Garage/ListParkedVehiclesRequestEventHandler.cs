using Garage.Library;
using Garage.UI;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class ListParkedVehiclesRequestEventHandler(
        Garage<Vehicle> garage,
        ListVehiclesMenu listParkedVehiclesMenu,
        IApplicationRequest request,
        ILogger<ListParkedVehiclesRequestEventHandler> logger)
        : ApplicationEventHandler<ListParkedVehiclesRequestEvent>(logger)
    {
        public ListParkedVehiclesDTO? Props { get; private set; } = null;
        protected override void _handle<TEvent>(TEvent @event)
        {
            logger.LogDebug("Processing data for event: {Event}", @event);
            ListParkedVehiclesDTO parsedPayload = (ListParkedVehiclesDTO)@event.Payload;
            Props = parsedPayload;
            logger.LogDebug("Props set: {}", Props);

            Queue<Vehicle>? vehicles = garage.GetAll();

            // Reset the menu items list
            listParkedVehiclesMenu.ResetMenuItems();
            
            static string FormatRow(string col1, string col2, string col3) => 
                String.Format("{0,-16}{1,-16}{2,-16}", col1, col2, col3) ;
            // Add menu items to the list
            for (int i = 0; i < garage.Count; i++)
            {
                Vehicle vehicle = vehicles.Dequeue();
                if (vehicle != null)
                    listParkedVehiclesMenu.AddMenuItem(new MenuItemDTO(
                        name: FormatRow(vehicle.Props.Make, vehicle.Props.Color, vehicle.Props.Type.ToString())));
            }

            // Update the menu
            listParkedVehiclesMenu.SetDescription(
                "Showing all vehicles currently parked in the garage:" + 
                "\n\n\t" +
                FormatRow("Make:", "Color:", "Type:") +
                "\n____________________________________________________");

            // Trigger the response event for the response handler to render the updated menu
            CancellationToken stoppingToken = new();
            _ = request.PublishAsync(
                new ListParkedVehiclesResponseEvent(new ListParkedVehiclesResponseDTO(vehicles)),
                stoppingToken
            );
        }

        public override void SetNext(IHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}
