using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public abstract class ConsoleUIComponent(
        string name,
        string displayName,
        string description,
        string prompt
        ) : IRender
    {
        public string Name { get; protected set; } = name;
        public string DisplayName { get; protected set; } = displayName;
        public string Description { get; protected set; } = description;

        
        public MenuSelection? Selection { get; protected set; } = null;
        protected string _availableOptionsMessage { get; set; } = "";
        private MenuList _menuListItems { get; set; } = [];
        protected List<MenuListItem> MenuListItems { 
            get => _menuListItems.ToList(); 
        }
        
        protected  readonly string _selectionPrompt = prompt;

        protected List<MenuListItem> GetMenuItems()
        {
            return _menuListItems.ToList();
        }
        public virtual void SetDisplayName(string newName)
        {
            DisplayName = new string(newName);
        }

        public virtual void ResetMenuItems()
        {
            _menuListItems = [];
        }

        public virtual void SetMenuItems(IEnumerable<MenuItemDTO> items)
        {
            foreach (MenuItemDTO item in items) {
                _menuListItems.Add(item);
            }
        }

        public void SetFormInputs(IEnumerable<FormInputDTO> items)
        {
            foreach (FormInputDTO item in items)
            {
                _menuListItems.Add(item);
            }
        }

        public virtual void AddMenuItem(MenuItemDTO item)
        {
            _menuListItems.Add(item);
        }

        protected void AddMenuItem(FormInputDTO input)
        {
            _menuListItems.Add(input);
        }

        public abstract void Render();

        protected MenuSelection TryGetMenuSelectionFromConsoleKeyInfo(ConsoleKeyInfo selectionInput)
        {
            if (selectionInput.Key == ConsoleKey.Escape)
            {
                return new MenuSelection(0);
            }

            var inputChar = selectionInput.KeyChar;
            if (!int.TryParse(inputChar.ToString(), out int option))
                throw new Exception($"'{inputChar}' is not an available option. Please use a number to make a selection from the list.");

            var found = _menuListItems.FirstOrDefault(item => item.Option.Equals(option));
            if (found == null)
                return new MenuSelection(option);
            return new MenuSelection(option, found);
        }
        protected static string BuildAvailableOptionsMessage(List<MenuListItem> menuListItems)
        {
            if (menuListItems.Count < 1) return "";
            string firstOptionString = $"'{menuListItems.ToArray()[0].Option}'";
            string additionalOptionsString = "";
            string availableOptionsString = "";
            foreach ((int availableOption, int index) in menuListItems.Select((item, index) => (item.Option, index)))
            {
                if (menuListItems.Count > 1)
                {
                    if (index > 0)
                    {
                        string separator = index + 1 == menuListItems.Count ? " and " : ", ";
                        additionalOptionsString += $"{separator}'{availableOption}'";
                    }
                    availableOptionsString = $"Available options are {firstOptionString}{additionalOptionsString}.";
                }
                else
                {
                    availableOptionsString = $"The only available option is {firstOptionString}.";
                }
            }
            return availableOptionsString;
        }
    }
}
