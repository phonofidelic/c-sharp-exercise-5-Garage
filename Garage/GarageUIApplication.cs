using Garage.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageUIApplication(string name) : Application(name)
    {
        public override ApplicationStatus Run()
        {
            bool exitApplication = false;
            MenuList<MenuListItem> options =
            [
                new(
                    name: "List vehicles", 
                    option: 1, 
                    subMenu: new(
                        name: "Parked Vehicles", 
                        description: "Showing all vehicles currently parked in the garage:", 
                        [new("Vehicle ABC-123 (car)", 1), new("Vehicle DEF-456 (bus)", 2), new("Vehicle GHI-789 (bike)", 3) ], 
                        selectionPrompt: "Press 'Esc' to go back."
                    )
                ),
                new(
                    name: "Park a vehicle", 
                    option: 2, 
                    subMenu: new(
                        name: "Enter vehicle details", 
                        description: "", 
                        [ new("Enter VIN:", 1), new("Enter vehicle type:", 2) ],
                    selectionPrompt: "\nSelect an option from the menu"
                    )
                ),
                new(
                    name: "Remove a vehicle", 
                    option: 3, 
                    subMenu: new(
                        name: "Remove vehicle", 
                        description: "Select a vehicle to remove from the garage:", 
                        [new("Vehicle ABC-123 (car)", 1), new("Vehicle DEF-456 (bus)", 2), new("Vehicle GHI-789 (bike)", 3) ], 
                        selectionPrompt: "Press 'Esc' to go back."
                    )
                ),
            ];

            ConsoleMenu mainMenu = new(
                name: "Main menu",
                description: "Use the menu to make a selection:",
                options,
                selectionPrompt: "\nSelect an option from the menu. Press 'Esc.' to quit the application"
                );

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
            ConsoleUI.WriteLine("\n\nPress 'Y' to confirm, any other key to cancel");
            nextKeyInfo = answer();
            return nextKeyInfo.Key == ConsoleKey.Y;
        }
        
    }
}
