namespace Garage.UI
{
    public class MenuListItem : IRender
    {
        public string Name { get; private set; }
        public int Option { get; private set; }

        public ConsoleMenu? SubMenu { get; private set; }
        public MenuListItem(string name, int option, ConsoleMenu subMenu)
        {
            Name = name;
            Option = option;
            SubMenu = subMenu;
        }
        public MenuListItem(string name, int option)
        {
            Name = name;
            Option = option;
            SubMenu = null;
        }

        public void Render()
        {
            ConsoleUI.WriteLine($"{Option}. {Name}");
        }
    }
} 