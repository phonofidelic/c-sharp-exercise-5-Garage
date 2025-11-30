using System.Collections;

namespace Garage.UI
{
    public class FormTextInput : FormInput
    {

        public FormTextInput(
        string name,
        string description)
            : base(name, description)
        { }

        public FormTextInput(
        string name,
        string description,
        string defaultValue)
            : base(name, description, defaultValue)
        { }


        public override string? Render()
        {
            string? input = ConsoleUI.GetInputFromReadLine(Description);
            // ToDo: Validate input
            Value = input;
            return Value;
        }
    }
}