using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public abstract class ConsoleMenu(string name, string description, MenuList<MenuListItem> menuListItems, string selectionPrompt) : IRender
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public MenuSelection? PreviousSelection { get; protected set; } = null;
        public MenuSelection? Selection { get; protected set; } = null;
        public Exception? MenuException { get; protected set; } = null;
        protected readonly MenuList<MenuListItem> _menuListItems = menuListItems;
        protected readonly string _selectionPrompt = selectionPrompt;
        protected readonly string _availableMenuOptionsMessage = BuildAvailableOptionsMessage(menuListItems);

        public virtual void Render(ConsoleKeyInfo? nextKey) {
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
                
                var selectionInput = ConsoleUI.GetSelectionFromReadKey(_selectionPrompt);
                MenuException = null;
                
                if (_menuListItems.Count > 0)
                {
                    Selection = TryGetMenuSelectionFromConsoleKeyInfo(selectionInput);
                    if (Selection.Option == 0)
                    {
                        break;
                    }

                        if (Selection.Option > _menuListItems.Count)
                    {
                        throw new Exception($"'{Selection.Option}' is not an available option. {_availableMenuOptionsMessage}");
                    }

                    var selectedItem = _menuListItems.FirstOrDefault(item => item.Option == Selection.Option);
                    selectedItem?.SubMenu?.Render(selectionInput);
                }

                // If the current menu has no children...
                if (_menuListItems.Count == 0)
                    // Go back to previous screen
                    Selection = new(0);
            }
            catch (Exception ex) {
                MenuException = new Exception($"Error in '{Name}':\n{ex.Message}");
                Selection = null;
            }

            if (Selection?.Option > 0)
                Selection = null;
        } while (Selection == null);
    }
           
        protected MenuSelection TryGetMenuSelectionFromConsoleKeyInfo(ConsoleKeyInfo selectionInput)
        {
            if (selectionInput.Key == ConsoleKey.Escape)
            {
                return new MenuSelection(0);
            }

            var inputChar = selectionInput.KeyChar;
            if (!int.TryParse(inputChar.ToString(), out int option))
                throw new Exception($"'{inputChar}' is not an available option. Please use a number to make a selection from the list.");

            var found = _menuListItems.FirstOrDefault(item => item.Option == option);
            if (found == null)
                return new MenuSelection(option);
            return new MenuSelection(option, found);
        }

        protected static string BuildAvailableOptionsMessage(MenuList<MenuListItem> menuListItems)
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
