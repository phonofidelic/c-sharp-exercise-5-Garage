using System;
using Garage.UI;

namespace Garage;

internal class ListVehiclesMenu(): ConsoleMenu
(
    name: "Parked Vehicles", 
    description: "Showing all vehicles currently parked in the garage:", 
    menuListItems: 
    [
        new(1, "Vehicle ABC-123 (car)"), 
        new(2, "Vehicle DEF-456 (bus)"), 
        new(3, "Vehicle GHI-789 (bike)") 
    ], 
    selectionPrompt: "Press 'Esc.' to go back"
) {}
