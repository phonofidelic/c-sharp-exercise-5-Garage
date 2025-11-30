using System.Collections;

namespace Garage.UI
{
    public class FormTextInput(
        string name, 
        string description) 
        : FormInput(name, description)
    {
        
        public override string? Render()
        {
            string? input = ConsoleUI.GetInputFromReadLine(Description);
            // ToDo: Validate input
            Value = input;
            return Value;
        }
    }
}