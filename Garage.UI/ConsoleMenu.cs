namespace Garage.UI
{
    public abstract class ConsoleMenu<TProps> : IRender where TProps : class
    
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public MenuSelection? Selection { get; protected set; } = null;
        public Exception? MenuException { get; protected set; } = null;
        protected MenuList _menuListItems { get; set; }
        protected readonly string _selectionPrompt;
        protected readonly string _availableMenuOptionsMessage;

        public ConsoleMenu(
        string name, 
        string description, 
        IEnumerable<MenuItemDTO> menuListDtoItems, 
        string selectionPrompt
        )
        {
            Name = name;
            Description = description;

            _menuListItems = new MenuList(menuListDtoItems);
            _selectionPrompt = selectionPrompt;
            _availableMenuOptionsMessage = BuildAvailableOptionsMessage(_menuListItems);
        }
        public virtual void Render() {
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
                    if (Selection.Option.Equals(0))
                    {
                        break;
                    }

                    var selectedItem = _menuListItems
                    .FirstOrDefault(item => item.Option.Equals(Selection.Option)) ?? 
                        throw new Exception($"'{Selection.Option}' is not an available option. {_availableMenuOptionsMessage}");
                    
                    selectedItem?.Children?.Render();
                }

                // If the current menu has no children...
                if (_menuListItems.Count == 0)
                    // Go back to previous screen
                    Selection = new MenuSelection(0);
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

            var found = _menuListItems.FirstOrDefault(item => item.Option.Equals(option));
            if (found == null)
                return new MenuSelection(option);
            return new MenuSelection(option, found);
        }

        protected static string BuildAvailableOptionsMessage(MenuList menuListItems)
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
                } else
                {
                    availableOptionsString = $"The only available option is {firstOptionString}.";
                }
            }
            return availableOptionsString;
        }
    }
}
