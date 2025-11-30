namespace Garage.UI
{
    public class MenuListItem : IRender
    {
        public string Name { get; private set; }
        public int Option { get; private set; }
        public string? Description { get; private set; }
        public IRender? Children { get; private set; }
        public FormInput? Input { get; private set; }

        public MenuListItem(int option, string name, IRender children)
        {
            Name = name;
            Option = option;
            Children = children;
            Input = null;
        }

        public MenuListItem(int option, string name, string description, FormInput input)
        {
            Name = name;
            Option = option;
            Description = description;
            Children = null;
            Input = input;
        }

        public MenuListItem(int option, string name)
        {
            Name = name;
            Option = option;
            Children = null;
            Input = null;
        }

        public void Render()
        {
            ConsoleUI.WriteLine($"{Option}.\t{Name}");
        }
    }
} 