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
    menuListDtoItems:
    [
        new("Vehicle ABC-123 (car)"),
        new("Vehicle DEF-456 (bus)"),
        new("Vehicle GHI-789 (bike)"),
    ],
    selectionPrompt: "Press 'Esc.' to go back"
)
    {
        // Get parked Vehicles from storage
        // Garage.ListAll()
    }
}
