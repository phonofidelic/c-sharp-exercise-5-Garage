using Garage.UI;

namespace Garage
{
    internal class ApplicationManager
    {
        public int? Selection { get; private set; }
        public ApplicationManager()
        {
            Selection = null;
        }

        internal void Run()
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
            } while (Selection == null);
        }
    }
}