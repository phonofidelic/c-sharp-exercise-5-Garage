using Garage.UI;

namespace Garage;

public class CreateNewGarageFormSubmit(
        string name, 
        string description,
        Action submitAction) 
        : FormInput(name, description)
{
    public override string? Render()
    {
        submitAction();
        return null;
    }
}
