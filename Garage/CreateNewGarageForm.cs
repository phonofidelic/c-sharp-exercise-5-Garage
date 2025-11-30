using Garage.Library;
using Garage.UI;

namespace Garage
{
    internal class CreateNewGarageForm 
        : ConsoleForm<CreateGarageRequestDTO>, IRender
    {
        private IApplicationRequest _request;
        public CreateNewGarageForm(
            Garage<Vehicle> garage,
            IApplicationRequest request)
        : base(
            name: "Create Garage Form",
            displayName: "Create a new Garage",
            description: "Initialize a new Garage by giving it a name and indicating its capacity.",
            inputs: [],
            inputPrompt: "Select a property from the menu to configure."
        )
        {
            _request = request;
             
            _menuListItems.Add(new FormInputDTO(
                name: "Name", 
                description: "Enter a name for your new garage:",
                type: FormInputType.Text,
                defaultValue: garage.Name));

            _menuListItems.Add(new FormInputDTO(
                name: "Capacity",
                description: "Enter the maximum capacity of your garage:",
                type: FormInputType.Text,
                defaultValue: garage.Capacity.ToString()));

            _menuListItems.Add(new FormInputDTO(
                name: "Submit",
                description: "Re-initialize the garage",
                type: FormInputType.Submit));
        }

        public override CreateGarageRequestDTO ParseFormData(Dictionary<string, string> rawFormData)
        {
            var name = rawFormData["Name"] ?? throw new Exception("'Name' is a required field");
            var capacity = rawFormData["Capacity"] ?? throw new Exception("'Capacity' is a required field");
            if (!int.TryParse(capacity, out int capacityInt))
                throw new Exception("'Capacity must be a number'");
            if (capacityInt < 1)
                throw new Exception("'Capacity' must be greater than 0");
            
            return new(name, capacityInt);
        }

        public override async Task Submit()
        {
            var parsedFormData = ParseFormData(FormData) ?? throw new Exception($"Form data is incomplete: {FormData}");
            CancellationToken stoppingToken = new();
            await _request.Publish(new CreateGarageRequestEvent(parsedFormData), stoppingToken);
        }
    }
}