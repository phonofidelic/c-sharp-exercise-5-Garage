using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class ConsoleMenu : IRender
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public int? Selection { get; private set; }

        private MenuList<MenuListItem> _menuListItems;
        
        public ConsoleMenu(string name, string description, MenuList<MenuListItem> options)
        {
            Name = name;
            Description = description;
            Selection = null;
            _menuListItems = options;
        }

        public void Render() {
            do
            {
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{Name}\n\n");
                ConsoleUI.WriteLine($"{Description}\n");
                foreach (var option in _menuListItems)
                {
                    option.Render();
                }

                try
                {
                    Selection = ConsoleUI.GetSelectionFromReadKey();
                }
                catch (Exception ex) {
                    throw new Exception($"Error in {Name}:\n{ex.Message}");
                }

                var selectedMenuListItem = _menuListItems.FirstOrDefault(item => item.Option == Selection);
                selectedMenuListItem?.SubMenu?.Render();
                
            } while (Selection == null);
        }
    }
}
