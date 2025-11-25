using System;
using Garage.UI;

namespace Garage;

internal class MainMenu(): ConsoleMenu
(
    name: "Main menu",
    description: "Use the menu to make a selection:",
    menuListItems : [
        new(
            option: 1, 
            name: "List parked vehicles", 
            subMenu: new ListVehiclesMenu()
        ),
        new(
            option: 2, 
            name: "Park a new vehicle", 
            subMenu: new ParkNewVehicleMenu()
        ),
        new(
            option: 3, 
            name: "Remove a parked vehicle", 
            subMenu: new RemoveVehicleMenu()
        )
    ],
    selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application"
) {}