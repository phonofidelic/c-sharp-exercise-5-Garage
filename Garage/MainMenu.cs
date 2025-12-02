using Garage.Library;
using Garage.UI;

namespace Garage;

internal class MainMenu : ConsoleMenu
{

    public MainMenu(
        Garage<Vehicle> garage,
    CreateNewGarageForm createNewGarageMenu,
    ListVehiclesView listVehiclesView,
    ParkNewVehicleForm parkNewVehicleForm,
    RemoveVehicleMenu removeVehicleMenu
    )
        : base(
    name: "Main Menu",
    displayName: garage.Name,
    description: "Use the menu to make a selection:",
    menuItems: [
                    new(
                        name: "Create new Garage",
                        children: createNewGarageMenu
                    ),
                    new(
                        name: "List parked vehicles",
                        children: listVehiclesView
                    ),
                    new(
                        name: "Park a new vehicle",
                        children: parkNewVehicleForm
                    ),
                    new(
                        name: "Remove a parked vehicle",
                        children: removeVehicleMenu
                    )
                ],
    selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application")
    { }
}

public record MainMenuDTO();