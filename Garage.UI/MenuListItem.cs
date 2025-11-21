namespace Garage.UI
{
    public class MenuListItem : IRender
    {
        public string Name { get; private set; }
        public MenuListItem(string name)
        {
            Name = name;
        }

        public void Render()
        {
            ConsoleUI.WriteLine($"{Name}");
        }
    }
} 