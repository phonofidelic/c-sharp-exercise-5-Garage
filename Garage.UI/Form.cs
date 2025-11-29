using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class FormInputDTO<TFormData>
    {
        public string Name { get; private set; }
        public string InputPrompt { get; set; }
        //public IInput Children { get; private set; }

        public FormInputDTO(string name, string inputPrompt)
        {
            Name = name;
            InputPrompt = inputPrompt;
            //Children = children;
        }
        //public FormInputDTO(string name)
        //{
        //    Name = name;
        //    Children = null;
        //}

    }
    public class Form<TFormData> : IRender where TFormData : class
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        protected FormSelection? Selection { get; set; }

        protected Exception? FormException { get; set; } = null;

        private List<FormListItem> _inputList = [];
        
        public TFormData? FormData { get; private set; } = null;

        private string _inputPrompt { get; set; }
        protected readonly string _availableFormOptionsMessage;
        private bool ISubmitted { get; set; } = false;
        private int Count { get; set; } = 0;

        public Form(
        string name,
        string description,
        string inputPrompt,
        IEnumerable<FormInputDTO<TFormData>> inputs
        )
        {
            Name = name;
            Description = description;
            _inputPrompt = inputPrompt;
            foreach (var input in inputs)
            {
                Add(input);
            }

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
                    ConsoleUI.WriteLine($"{input.Option}.\t{input.Name}");
                }

                try
                {
                    var selectionInput = ConsoleUI.GetSelectionFromReadKey(_inputPrompt);
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

                        selectedItem?.Render();
                    }
                } catch (Exception ex)
                {
                    FormException = ex;
                    Selection = null;
                }

                ConsoleUI.WriteLine(_inputPrompt);
                ConsoleUI.GetSelectionFromReadKey("Select a property from the menu to configure.");
            } while (Selection == null);
        }

        protected void Add(FormInputDTO<TFormData> input) {
            Count++;
            _inputList.Add(new FormListItem(Count, input.Name, input.InputPrompt));
        }

        private void SetFormData()
        {

        }

        private void Submit()
        {

        }

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
        protected static string BuildAvailableOptionsMessage(List<FormListItem> menuListItems)
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
