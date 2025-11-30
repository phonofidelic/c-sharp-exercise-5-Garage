using Garage.UI;
using System;
using System.Diagnostics.Metrics;

namespace Garage;

internal class ParkNewVehicleMenu(): ConsoleMenu
(
    name: "Add new vehicle menu", 
    displayName: "Enter vehicle details",
    description: "", 
    [ 
        new("Enter VIN:"), 
        new("Enter vehicle type:") 
    ],
    selectionPrompt: "Select an option from the menu.\nPress 'Esc.' to go back"
) {}