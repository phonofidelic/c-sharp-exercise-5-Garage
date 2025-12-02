namespace Garage.UI
{
    public abstract class ConsoleMenu : ConsoleUIComponent

    {
        protected abstract Exception? MenuException { get; set; }

        public ConsoleMenu(
        string name,
        string displayName,
        string description,
        IEnumerable<MenuItemDTO> menuItems,
        string selectionPrompt
        ) : base(
            name, 
            displayName, 
            description, 
            selectionPrompt)
        {
            List<MenuListItem> menuListItems = SetMenuItems(menuItems);
            _availableOptionsMessage = BuildAvailableOptionsMessage(menuListItems);
        }
        public override void Render()
        {
            ResetMenuSelection();
            List<MenuListItem> menuListItems;
            do
            {
                menuListItems = GetMenuItems();
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{DisplayName}\n\n");
                ConsoleUI.WriteLine($"{Description}\n");
                foreach (var item in menuListItems)
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

                    Selection = TryGetMenuSelectionFromConsoleKeyInfo(selectionInput);
                    if (Selection.Option > 0)
                    {
                        var selectedItem = menuListItems
                        .FirstOrDefault(item => item.Option.Equals(Selection.Option)) ??
                            throw new Exception($"'{Selection.Option}' is not an available option. {_availableOptionsMessage}");

                        selectedItem?.Children?.Render();
                        ResetMenuSelection();
                    }
                }
                catch (Exception ex)
                {
                    MenuException = new Exception($"Error in '{Name}':\n{ex.Message}");
                    ResetMenuSelection();
                }

                if (Selection?.Option > 0)
                    ResetMenuSelection();
            } while (Selection?.Option != 0);
        }
    }
}

