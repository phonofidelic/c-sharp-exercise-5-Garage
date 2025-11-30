namespace Garage.UI
{
    public record FormInputDTO
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public FormInputType Type { get; set; }
        public string? DefaultValue { get; set; } = null;
        public FormInputDTO(
            string name, 
            string description, 
            FormInputType type)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = null;
        }

        public FormInputDTO(
            string name, 
            string description, 
            FormInputType type, 
            string defaultValue)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = defaultValue;
        }

        public FormInputDTO(
            string description,
            FormInputType type = FormInputType.Submit)
        {
            Name = "Submit";
            Description = description;
            Type = FormInputType.Submit;
            DefaultValue = null;
        }
    }
    
    public enum FormInputType
    {
        Text,
        Submit
    }
}
