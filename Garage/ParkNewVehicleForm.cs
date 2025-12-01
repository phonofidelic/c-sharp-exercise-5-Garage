using Garage.UI;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Garage;

internal class ParkNewVehicleForm : ConsoleForm<ParkNewVehicleRequestDTO>, IRender
{
    public ParkNewVehicleForm()
        : base(
    name: "Add new vehicle form",
    displayName: "Enter vehicle details",
    description: "Enter details for the vehicle to be parked",
    inputs: [
        new FormInputDTO(
            name: "VIN",
            description: "Enter vehicle identification number:",
            type: FormInputType.Text),
        new FormInputDTO(
            name: "Make",
            description: "Vehicle make:",
            type: FormInputType.Text),
        new FormInputDTO(
            description: "Park new vehicle",
            type: FormInputType.Submit)
    ],
    inputPrompt: "Select an option from the menu.\nPress 'Esc.' to go back"
)
    {

    }

    public override ParkNewVehicleRequestDTO ParseFormData(Dictionary<string, string> rawFormData)
    {
        throw new NotImplementedException();
    }

    public override Task Submit()
    {
        throw new NotImplementedException();
    }
}
 