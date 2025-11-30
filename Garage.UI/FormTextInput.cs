using System.Collections;

namespace Garage.UI
{
    public class FormTextInput(
        // int option, 
        string name, 
        string description) 
        : FormInput(name, description)
    {
        public override string? Render()
        {
            return ConsoleUI.GetInputFromReadLine(Description);
        }
    }
}