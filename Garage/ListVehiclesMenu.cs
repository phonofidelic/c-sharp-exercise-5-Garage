using System;
using Garage.Library;
using Garage.UI;

namespace Garage;

internal class ListVehiclesMenu: ConsoleMenu
{
    public ListVehiclesMenu(Garage<Vehicle> garage)
        : base(
    name: "Parked Vehicles",
    displayName: "Parked Vehicles",
    description: "Showing all vehicles currently parked in the garage:",
    menuItems: [],
    selectionPrompt: "Press 'Esc.' to go back"
)
    {
        // Get parked Vehicles from storage
        List<Vehicle> vehicles = garage.GetAll();

        foreach(Vehicle vehicle in vehicles)
        {
            if (vehicle != null) {
                ListParkedVehiclesDTO props = (ListParkedVehiclesDTO)vehicle.Props;
            
                var (Make, Color, Type) = props;

                // ToDo: Handle VIN display
                string menuItemName = $"\tModel: {Make}\tColor: {Color}\t Type {Type}";
                AddMenuItem(new MenuItemDTO(
                    name: menuItemName));
            }
            
        }

    }
}
