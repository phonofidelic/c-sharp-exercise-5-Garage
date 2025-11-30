namespace Garage.UI
{
    public class MenuItemDTO
    {
        public string Name { get; private set; }
        public IRender? Children { get; private set; }

        public MenuItemDTO(string name, IRender children)
        {
            Name = name;
            Children = children;
        }
        public MenuItemDTO(string name)
        {
            Name = name;
            Children = null;
        }
    }
}
