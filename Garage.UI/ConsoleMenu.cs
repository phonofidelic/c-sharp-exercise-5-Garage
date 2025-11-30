namespace Garage.UI
{
    public abstract class ConsoleMenu : ConsoleUIComponent

    {
        public Exception? MenuException { get; protected set; } = null;

        public ConsoleMenu(
        string name,
        string displayName,
        string description,
        IEnumerable<MenuItemDTO> menuListDtoItems,
        string selectionPrompt
        ) : base(name, displayName, description, selectionPrompt)
        {
            _menuListItems = new MenuList(menuListDtoItems);
            _availableOptionsMessage = BuildAvailableOptionsMessage(_menuListItems);
        }
        public override void Render()
        {
            do
            {
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{DisplayName}\n\n");
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
                        if (Selection.Option.Equals(0))
                        {
                            break;
                        }

                        var selectedItem = _menuListItems
                        .FirstOrDefault(item => item.Option.Equals(Selection.Option)) ??
                            throw new Exception($"'{Selection.Option}' is not an available option. {_availableOptionsMessage}");

                        selectedItem?.Children?.Render();
                    }

                    // If the current menu has no children...
                    if (_menuListItems.Count == 0)
                        // Go back to previous screen
                        Selection = new MenuSelection(0);
                }
                catch (Exception ex)
                {
                    MenuException = new Exception($"Error in '{Name}':\n{ex.Message}");
                    Selection = null;
                }

                if (Selection?.Option > 0)
                    Selection = null;
            } while (Selection == null);
        }
    }
}

