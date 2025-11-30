namespace Garage.UI;

public class FormSubmit(
        string name, 
        string description) 
        : FormInput(name, description)
{
    public override string? Render()
    {
        return "Submitted";
    }
}
