namespace Garage.UI
{
    public class MenuListItem : IRender
    {
        public string Name { get; private set; }
        public int Option { get; private set; }

        public IRender? SubMenu { get; private set; }
        public MenuListItem(int option, string name, IRender subMenu)
        {
            Name = name;
            Option = option;
            SubMenu = subMenu;
        }
        public MenuListItem(int option, string name)
        {
            Name = name;
            Option = option;
            SubMenu = null;
        }

        // ToDo: refine Render method
        public void Render(ConsoleKeyInfo? _ = null)
        {
            ConsoleUI.WriteLine($"{Option}. {Name}");
        }
    }
} 