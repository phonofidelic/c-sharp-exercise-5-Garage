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
                    name: "List vehicles", 
                    option: 1, 
                    subMenu: new ListVehiclesMenu()
                ),
                new(
                    name: "Park a vehicle", 
                    option: 2, 
                    subMenu: new ParkNewVehicleMenu()
                ),
                new(
                    name: "Remove a vehicle", 
                    option: 3, 
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
                ConsoleUI.WriteLineInfo("Press 'Esc.' to quit the application.");
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

    internal class MainMenu(MenuList<MenuListItem> menuListItems): ConsoleMenu(
        name: "Main menu",
        description: "Use the menu to make a selection:",
        menuListItems,
        selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application"
    ) {}

    internal class ListVehiclesMenu(): ConsoleMenu(
        name: "Parked Vehicles", 
        description: "Showing all vehicles currently parked in the garage:", 
        menuListItems: [new("Vehicle ABC-123 (car)", 1), new("Vehicle DEF-456 (bus)", 2), new("Vehicle GHI-789 (bike)", 3) ], 
        selectionPrompt: "Press 'Esc' to go back."
    ) {}

    internal class ParkNewVehicleMenu(): ConsoleMenu(
        name: "Enter vehicle details", 
        description: "", 
        [ new("Enter VIN:", 1), new("Enter vehicle type:", 2) ],
        selectionPrompt: "Select an option from the menu"
    ) {}

    internal class RemoveVehicleMenu(): ConsoleMenu(
        name: "Remove vehicle", 
        description: "Select a vehicle to remove from the garage:", 
        [new("Vehicle ABC-123 (car)", 1), new("Vehicle DEF-456 (bus)", 2), new("Vehicle GHI-789 (bike)", 3) ], 
        selectionPrompt: "Press 'Esc' to go back."
    ) {}
}
