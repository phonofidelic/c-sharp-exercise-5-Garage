using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    internal class GarageUIApplication(string name) : Application(name)
    {
        public override ApplicationStatus Run()
        {
            bool exitApplication = false;
            MenuList<MenuListItem> mainMenuItems =
            [
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
                ),
            ];

            
            MainMenu mainMenu = new( menuListItems: mainMenuItems );

            ConsoleKeyInfo? nextKey = null;

            do
            {
                try
                {
                    mainMenu.Render(nextKey);
                } catch (Exception ex)
                {
                    return new ApplicationStatus(-1, ex);
                }
                ConsoleUI.WriteLineInfo("Press 'Esc.' to quit the application");
                exitApplication = ConfirmExit(() => ConsoleUI.ReadKey(intercept: true), out ConsoleKeyInfo nextKeyInfo);
                nextKey = nextKeyInfo;
            } while(!exitApplication);

            return new ApplicationStatus(0);
        }

        private bool ConfirmExit(Func<ConsoleKeyInfo> answer, out ConsoleKeyInfo nextKeyInfo)
        {
            ConsoleUI.Clear();
            ConsoleUI.WriteLine($"\nAre you sure you want to quit {Name}?");
            ConsoleUI.Write("\n\n\tPress ");
            ConsoleUI.WriteColor("\"Y\" to confirm", ConsoleColor.Green);
            ConsoleUI.Write(", any other key to ");
            ConsoleUI.WriteColor("cancel", ConsoleColor.Red);
            nextKeyInfo = answer();
            return nextKeyInfo.Key == ConsoleKey.Y;
        }
    }

    internal class MainMenu(MenuList<MenuListItem> menuListItems): ConsoleMenu
    (
        name: "Main menu",
        description: "Use the menu to make a selection:",
        menuListItems,
        selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application"
    ) {}

    internal class ListVehiclesMenu(): ConsoleMenu
    (
        name: "Parked Vehicles", 
        description: "Showing all vehicles currently parked in the garage:", 
        menuListItems: 
        [
            new(1, "Vehicle ABC-123 (car)"), 
            new(2, "Vehicle DEF-456 (bus)"), 
            new(3, "Vehicle GHI-789 (bike)") 
        ], 
        selectionPrompt: "Press 'Esc.' to go back"
    ) {}

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
}
