using System;
using System.Collections;
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
        public MenuSelection? Selection { get; private set; } = null;
        public Exception? MenuException { get; private set; } = null;
        private readonly MenuList<MenuListItem> _menuListItems;

        private readonly string _availableMenuOptionsMessage = "This menu has no available options.";

        public ConsoleMenu(string name, string description, MenuList<MenuListItem> menuListItems)
        {
            Name = name;
            Description = description;
            _menuListItems = menuListItems;
            _availableMenuOptionsMessage = BuildAvailableOptionsMessage(menuListItems);
        }

        public void Render() {
            do
            {
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{Name}\n\n");
                ConsoleUI.WriteLine($"{Description}\n");
                foreach (var item in _menuListItems)
                {
                    item.Render();
                }

                if (MenuException != null)
                {
                    ConsoleUI.WriteException(MenuException.Message);
                }

                try
                {
                    var selectionInput = ConsoleUI.GetSelectionFromReadKey();
                    MenuException = null;
                    Selection = TryGetMenuSelectionFromConsoleKeyInfo(selectionInput, out int option);
                    if (Selection.Item == null)
                    {
                        throw new Exception($"'{Selection.Option}' is not an available option. {_availableMenuOptionsMessage}");
                    }
                }
                catch (Exception ex) {
                    MenuException = new Exception($"Error in '{Name}':\n{ex.Message}");
                    Selection = null;
                }
                Selection?.Item?.Render();
                
            } while (Selection == null);
        }

        private MenuSelection TryGetMenuSelectionFromConsoleKeyInfo(ConsoleKeyInfo selectionInput, out int option)
        {
            if (selectionInput.Key == ConsoleKey.Q)
            {
                option = 0;
                return new MenuSelection(0);
            }

            var inputChar = selectionInput.KeyChar;
            if (!int.TryParse(inputChar.ToString(), out int intOption))
                throw new Exception($"'{inputChar}' is not an available option. Please use a number to make a selection from the list.");

            option = intOption;
            var found = _menuListItems.FirstOrDefault(item => item.Option == intOption);
            if (found == null)
                return new MenuSelection(option);
            return new MenuSelection(option, found);
        }

        private static string BuildAvailableOptionsMessage(MenuList<MenuListItem> menuListItems)
        {
            if (menuListItems.Count < 1) return "";
            string firstOption = $"'{menuListItems.ToArray()[0].Option}'";
            string additionalOptions = "";
            string availableOptions = "";
            foreach ((int availableOption, int index) in menuListItems.Select((item, index) => (item.Option, index)))
            {
                if (menuListItems.Count > 1)
                {
                    if (index > 0)
                    {
                        string separator = index + 1 == menuListItems.Count ? " and " : ", ";
                        additionalOptions += $"{separator}'{availableOption}'";
                    }
                    availableOptions = $"Available options are {firstOption}{additionalOptions}.";
                } else
                {
                    availableOptions = $"The only available option is '1'.";
                }
            }
            return availableOptions;
        }
    }

    public class MenuSelection
    {
        public int Option { get; private init; }
        public MenuListItem? Item { get; private init; }
        public MenuSelection(int option, MenuListItem item)
        {
            Option = option;
            Item = item;
        }
        public MenuSelection(int option)
        {
            Option = option;
            Item = null;
        }
        
    }

}
