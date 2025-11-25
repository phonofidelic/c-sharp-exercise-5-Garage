using System;
using System.Reflection.Metadata.Ecma335;
using Garage.UI;

namespace Garage;


internal class MainMenu: ConsoleMenu

{
    public MainMenu()
    : base(
    name: "Main menu",
    description: "Use the menu to make a selection:",
    menuListDtoItems : [
            new(
                name: "Create new Garage"
            ),
            new(
                name: "List parked vehicles",
                children: new ListVehiclesMenu()
            ),
            new(
                name: "Park a new vehicle",
                children: new ParkNewVehicleMenu()
            ),
            new(
                name: "Remove a parked vehicle",
                children: new RemoveVehicleMenu()
            )
        ],
    selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application"
)
    {}
}