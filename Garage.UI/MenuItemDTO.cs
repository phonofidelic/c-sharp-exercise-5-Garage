namespace Garage.UI
{
    public record MenuItemDTO
    {
        public string Name { get; init; }
        public IRender? Children { get; init; }

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
