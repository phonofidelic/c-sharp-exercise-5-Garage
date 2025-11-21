using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageUIApplication : Application
    {
        public int? Selection { get; private set; }
        public override ApplicationStatus Start()
        {
            MenuList<MenuListItem> options =
            [
                new(name: "List vehicles"),
                new(name: "Park a vehicle"),
                new(name: "Remove a vehicle"),
            ];

            ConsoleMenu mainMenu = new(
                name: "Main menu",
                description: "Use the menu to make a selection:",
                options);

            do
            {
                mainMenu.Render();
                ConsoleUI.ReadLine();
                // ToDo: while (status.code > 0)
            } while (Selection == null);

            return new ApplicationStatus(0);
        }
    }
}
