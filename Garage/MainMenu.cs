using Garage.Library;
using Garage.UI;

namespace Garage;

internal class MainMenu : ConsoleMenu
{

    public MainMenu(
        Garage<Vehicle> garage,
    CreateNewGarageForm createNewGarageMenu,
    ListVehiclesMenu listVehiclesMenu,
    ParkNewVehicleForm parkNewVehicleForm
    )
        : base(
    name: "Main Menu",
    displayName: garage.Name,
    description: "Use the menu to make a selection:",
    menuListDtoItems: [
                    new(
                        name: "Create new Garage",
                        children: createNewGarageMenu
                    ),
                    new(
                        name: "List parked vehicles",
                        children: listVehiclesMenu
                    ),
                    new(
                        name: "Park a new vehicle",
                        children: parkNewVehicleForm
                    ),
                    new(
                        name: "Remove a parked vehicle",
                        children: new RemoveVehicleMenu()
                    )
                ],
    selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application"
    )
    { }
}

public record MainMenuDTO();