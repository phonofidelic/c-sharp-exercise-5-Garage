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

        // ToDo: Create `TextBlock` class?
        public string Description { get; private set; }

        private MenuList<MenuListItem> _options;
        
        public ConsoleMenu(string name, string description, MenuList<MenuListItem> options)
        {
            Name = name;
            Description = description;
            _options = options;
        }

        public void Render() {
            ConsoleUI.Clear();
            ConsoleUI.WriteLine($"{Name}\n\n");
            ConsoleUI.WriteLine($"{Description}\n");
            foreach (var option in _options) {
                option.Render();
            }
        }
    }
}
