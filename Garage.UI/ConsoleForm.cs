using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public abstract class Form<TFormData> : IRender where TFormData : class
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        protected FormSelection? Selection { get; set; }
        protected Exception? FormException { get; set; } = null;
        protected MenuList _inputList = [];
        public Dictionary<string, string> FormData { get; private set; } = [];
        private string _formPrompt { get; set; }
        protected readonly string _availableFormOptionsMessage;
        protected bool IsSubmitted { get; set; } = false;

        public Form(
        string name,
        string description,
        string inputPrompt,
        IEnumerable<FormInputDTO> inputs
        )
        {
            Name = name;
            Description = description;
            _formPrompt = inputPrompt;
            _inputList = new MenuList(inputs);

            _availableFormOptionsMessage = BuildAvailableOptionsMessage(_inputList);
        }

        public void Render()
        {
            do
            {
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{Name}\n\n");
                ConsoleUI.WriteLine($"{Description}\n");
                foreach(var input in _inputList)
                {
                    input.Render();
                }

                if (FormException != null)
                {
                    ConsoleUI.WriteException(FormException.Message);
                }

                try
                {
                    var selectionInput = ConsoleUI.GetSelectionFromReadKey(_formPrompt);
                    FormException = null;

                    if (_inputList.Count > 0)
                    {
                        Selection = TryGetMenuSelectionFromConsoleKeyInfo(selectionInput);
                        if (Selection.Option.Equals(0))
                        {
                            break;
                        }

                        var selectedItem = _inputList
                        .FirstOrDefault(item => item.Option.Equals(Selection.Option)) ??
                            throw new Exception($"'{Selection.Option}' is not an available option. {_availableFormOptionsMessage}");

                        if (selectedItem != null)
                        {
                            // ToDo: Don't use magic strings
                            if (selectedItem.Name == "Submit")
                            {
                                Submit();
                            } else
                            {
                                var newData = selectedItem.Input?.Render();
                                FormData[selectedItem.Name] = newData ?? "";
                            }
                        }

                        foreach(var key in FormData.Keys)
                        {
                            ConsoleUI.WriteLine($"{key}: {FormData[key]}");
                        }
                    }
                } catch (Exception ex)
                {
                    FormException = ex;
                    Selection = null;
                }
            } while (Selection == null || !IsSubmitted);
        }

        protected void ResetFormData()
        {
            FormData = [];
        }

        public abstract TFormData ParseFormData(Dictionary<string, string> rawFormData);
        
        public abstract Task Submit();

        protected FormSelection TryGetMenuSelectionFromConsoleKeyInfo(ConsoleKeyInfo selectionInput)
        {
            if (selectionInput.Key == ConsoleKey.Escape)
            {
                return new FormSelection(0);
            }

            var inputChar = selectionInput.KeyChar;
            if (!int.TryParse(inputChar.ToString(), out int option))
                throw new Exception($"'{inputChar}' is not an available option. Please use a number to make a selection from the list.");

            var found = _inputList.FirstOrDefault(item => item.Option.Equals(option));
            if (found == null)
                return new FormSelection(option);
            return new FormSelection(option, found);
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
    }
}
