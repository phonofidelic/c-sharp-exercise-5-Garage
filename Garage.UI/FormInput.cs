using System;

namespace Garage.UI;

public abstract class FormInput : IInput
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public FormInput(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public abstract string? Render();
}
