using System;
using Garage.UI;

namespace Garage;

internal class ListVehiclesMenu(): ConsoleMenu
(
    name: "Parked Vehicles", 
    description: "Showing all vehicles currently parked in the garage:", 
    menuListItems: 
    [
        new("Vehicle ABC-123 (car)"), 
        new("Vehicle DEF-456 (bus)"), 
        new("Vehicle GHI-789 (bike)"),
    ], 
    selectionPrompt: "Press 'Esc.' to go back"
) {}
