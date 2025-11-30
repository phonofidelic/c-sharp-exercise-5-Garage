namespace Garage.UI
{
    public record FormInputDTO
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public FormInput Input { get; init; }
        public FormInputDTO(string name, string description, FormInput input)
        {
            Name = name;
            Description = description;
            Input = input;
        }
    }
}
