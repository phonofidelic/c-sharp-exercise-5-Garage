using Garage.Library;
using Garage.UI;

namespace Garage
{
    internal class CreateNewGarageForm 
        : Form<CreateGarageRequestDTO>
    {
        private IApplicationRequest _request;
        public CreateNewGarageForm(
            IApplicationRequest request)
        : base(
            name: "Create a new Garage",
            description: "Initialize a new Garage by giving it a name and indicating its capacity.",
            inputs: [],
            inputPrompt: "Select a property from the menu to configure."
        )
        {
            _request = request;

            FormData["Name"] = null;
            FormData["Capacity"] = null;
             
            _inputList.Add(new FormInputDTO(
                "Name", 
                "Enter a name for your new garage:",
                new FormTextInput("Name",  "Enter a name for your new garage:")));

            _inputList.Add(new FormInputDTO(
                "Capacity",
                "Enter the maximum capacity of your garage:",
                new FormTextInput("Capacity", "Enter the maximum capacity of your garage:")));

            _inputList.Add(new FormInputDTO(
                "Submit",
                "Submit",
                new FormSubmit("Submit", "Submit")));
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
            try
            {
                var parsedFormData = ParseFormData(FormData) ?? throw new Exception($"Form data is incomplete: {FormData}");
                CancellationToken stoppingToken = new();
                await _request.Publish(new CreateGarageRequestEvent(parsedFormData), stoppingToken);
                
                // Form was submitted successfully
                ResetFormData();
                IsSubmitted = true;
                ConsoleUI.Clear();
                ConsoleUI.WriteLine("New garage was created successfully");
                ConsoleUI.Continue();
            } catch (Exception ex)
            {
                FormException = ex;
            }
        }
    }
}