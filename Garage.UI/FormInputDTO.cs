namespace Garage.UI
{
    public class FormInputDTO
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IInput Input { get; private set; }
        public FormInputDTO(string name, string description, IInput input)
        {
            Name = name;
            Description = description;
            Input = input;
        }
    }
}
