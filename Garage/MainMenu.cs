using Garage.Library;
using Garage.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace Garage;


internal class MainMenu(CreateGarageMenu createGarageMenu) : ConsoleMenu(
    name: "Main menu",
    description: "Use the menu to make a selection:",
    menuListDtoItems: [
                    new(
                        name: "Create new Garage",
                        children: createGarageMenu
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
{
    
}
