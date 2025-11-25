using System;
using Garage.UI;

namespace Garage;

internal class RemoveVehicleMenu(): ConsoleMenu
(
    name: "Remove vehicle", 
    description: "Select a vehicle to remove from the garage:", 
    [
        new(1, "Vehicle ABC-123 (car)"), 
        new(2, "Vehicle DEF-456 (bus)"), 
        new(3, "Vehicle GHI-789 (bike)") 
    ], 
    selectionPrompt: "Select an option from the menu.\nPress 'Esc.' to go back"
) {}