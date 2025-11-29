using System;
using Garage.UI;

namespace Garage;

internal class ParkNewVehicleMenu(): ConsoleMenu<ParkNewVehicleDTO>
(
    name: "Enter vehicle details", 
    description: "", 
    [ 
        new("Enter VIN:"), 
        new("Enter vehicle type:") 
    ],
    selectionPrompt: "Select an option from the menu.\nPress 'Esc.' to go back"
) {}

public record ParkNewVehicleDTO();