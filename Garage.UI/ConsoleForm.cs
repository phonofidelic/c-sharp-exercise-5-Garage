using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public abstract class ConsoleForm<TFormData> : ConsoleUIComponent, IRender, IRenderAsync where TFormData : class
    {
        public Dictionary<string, string> FormData { get; protected set; } = [];
        private string _formPrompt { get; set; }
        public Exception? FormException { get; protected set; } = null;
        protected bool IsSubmitted { get; set; } = false;

        public ConsoleForm(
        string name,
        string displayName,
        string description,
        string inputPrompt,
        IEnumerable<FormInputDTO> inputs
        ) : base(name, displayName, description, inputPrompt)
        {
            _formPrompt = inputPrompt;
            _menuListItems = new MenuList(inputs);

            _availableOptionsMessage = BuildAvailableOptionsMessage(_menuListItems);
        }

        public async Task RenderAsync()
        {
            do
            {
                ConsoleUI.Clear();
                ConsoleUI.WriteLine($"{DisplayName}\n\n");
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
                            break;
                        }

                        var selectedItem = _menuListItems
                        .FirstOrDefault(item => item.Option.Equals(Selection.Option)) ??
                            throw new Exception($"'{Selection.Option}' is not an available option. {_availableOptionsMessage}");

                        if (selectedItem != null)
                        {
                            // ToDo: Don't use magic strings
                            if (selectedItem.Name == "Submit")
                            {
                                await Submit().ConfigureAwait(true);
                       
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

        public override void Render()
        {
            _ = RenderAsync();
        }
    }
}
