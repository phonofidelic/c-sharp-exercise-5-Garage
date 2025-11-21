using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageUIApplication(string name) : Application(name)
    {
        public override ApplicationStatus Run()
        {
            MenuList<MenuListItem> options =
            [
                new(name: "List vehicles", 1, new("Parked Vehicles", "Showing all vehicles currently parked in the garage:", [])),
                new(name: "Park a vehicle", 2),
                new(name: "Remove a vehicle", 3),
            ];

            ConsoleMenu mainMenu = new(
                name: "Main menu",
                description: "Use the menu to make a selection:",
                options);

            try
            {
                mainMenu.Render();
            } catch (Exception ex)
            {
                return new ApplicationStatus(-1, ex);
            }
            ConsoleUI.Continue();
                // ToDo: while (status.code > 0)

            return new ApplicationStatus(0);
        }
    }
}
