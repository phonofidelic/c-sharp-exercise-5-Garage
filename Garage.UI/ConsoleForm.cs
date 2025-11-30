using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public abstract class ConsoleForm<TFormData> : IRender, IRenderAsync where TFormData : class
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        protected MenuSelection? Selection { get; set; }
        protected Exception? FormException { get; set; } = null;
        protected MenuList _menuListItems { get; set; }
        public Dictionary<string, string> FormData { get; protected set; } = [];
        private string _formPrompt { get; set; }
        protected readonly string _availableFormOptionsMessage;
        protected bool IsSubmitted { get; set; } = false;

        public ConsoleForm(
        string name,
        string description,
        string inputPrompt,
        IEnumerable<FormInputDTO> inputs
        )
        {
            Name = name;
            Description = description;
            _formPrompt = inputPrompt;
            _menuListItems = new MenuList(inputs);

            _availableFormOptionsMessage = BuildAvailableOptionsMessage(_menuListItems);
        }

        public async Task RenderAsync()
        {
            do
            {
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{Name}\n\n");
                ConsoleUI.WriteLine($"{Description}\n");
                foreach(var item in _menuListItems)
                {
                    item.Render();
                }

                // Display current form values
                ConsoleUI.WriteLine();
                foreach (var item in _menuListItems)
                {
                    // ToDo: Don't use magic strings
                    if (item.Name != "Submit") ConsoleUI.WriteLine($"\t{item.Name}: {item.Input?.Value}");
                }

                if (FormException != null)
                {
                    ConsoleUI.WriteException(FormException.Message);
                }

                try
                {
                    var selectionInput = ConsoleUI.GetSelectionFromReadKey(_formPrompt);
                    FormException = null;

                    if (_menuListItems.Count > 0)
                    {
                        Selection = TryGetMenuSelectionFromConsoleKeyInfo(selectionInput);
                        if (Selection.Option.Equals(0))
                        {
                            ResetFormData();
                            break;
                        }

                        var selectedItem = _menuListItems
                        .FirstOrDefault(item => item.Option.Equals(Selection.Option)) ??
                            throw new Exception($"'{Selection.Option}' is not an available option. {_availableFormOptionsMessage}");

                        if (selectedItem != null)
                        {
                            // ToDo: Don't use magic strings
                            if (selectedItem.Name == "Submit")
                            {
                                await Submit().ConfigureAwait(true);
                       
                                ResetFormData();
                                Selection = new(0);
                                IsSubmitted = true;
                                break;
                            } else
                            {
                                var newData = selectedItem.Input?.Render();
                                FormData[selectedItem.Name] = newData ?? "";
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    FormException = ex;
                    Selection = null;
                }
                if (Selection?.Option > 0)
                    Selection = null;
            } while (Selection == null || !IsSubmitted);
        }

        protected void ResetFormData()
        {
            FormData = [];
            foreach(var item in _menuListItems)
            {
                item.Input?.ResetValue();
            }
        }

        public abstract TFormData ParseFormData(Dictionary<string, string> rawFormData);
        
        public abstract Task Submit();

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
                }
                else
                {
                    availableOptionsString = $"The only available option is {firstOptionString}.";
                }
            }
            return availableOptionsString;
        }

        public void Render()
        {
            _ = RenderAsync();
        }
    }
}
