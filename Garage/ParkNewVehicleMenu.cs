using System;
using Garage.UI;

namespace Garage;

internal class ParkNewVehicleMenu(): ConsoleMenu
(
    name: "Enter vehicle details", 
    description: "", 
    [ 
        new(1, "Enter VIN:"), 
        new(2, "Enter vehicle type:") 
    ],
    selectionPrompt: "Select an option from the menu.\nPress 'Esc.' to go back"
) {}