using System;

namespace Garage.UI;

public abstract class FormInput : IInput
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string? Value { get; protected set; } = null;
    public FormInput(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void ResetValue()
    {
        Value = null;
    }
    public abstract string? Render();
}
