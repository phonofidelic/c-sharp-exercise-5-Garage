using Garage.Library;
using Garage.UI;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Garage;

internal class ParkNewVehicleForm : ConsoleForm<ParkNewVehicleRequestDTO>, IRender
{
    private IApplicationRequest _request;
    public ParkNewVehicleForm(
        IApplicationRequest request)
        : base(
    name: "Add new vehicle form",
    displayName: "Enter vehicle details",
    description: "Enter details for the vehicle to be parked",
    inputs: [
        new FormInputDTO(
            name: "Make",
            description: "Vehicle make:",
            type: FormInputType.Text),
        new FormInputDTO(
            name: "Color",
            description: "Vehicle color:",
            type: FormInputType.Text),
        new FormInputDTO(
            name: "Type",
            description: "Type of vehicle (car, bus or bicycle)",
            // ToDo: Make a "Select" input type
            type: FormInputType.Text),
        new FormInputDTO(
            name: "VIN",
            description: "Enter vehicle identification number (required for car and bus):",
            type: FormInputType.Text),
        new FormInputDTO(
            description: "Park new vehicle",
            type: FormInputType.Submit),
    ],
    inputPrompt: "Select an option from the menu.\nPress 'Esc.' to go back")
    {
        _request = request;
    }
    public override ParkNewVehicleRequestDTO ParseFormData(Dictionary<string, string> rawFormData)
    {
        if (!FormData.TryGetValue("Type", out string? vehicleType))
            throw new Exception("Vehicle Type is a required field");
        

        if (!Enum.TryParse<VehicleType>(vehicleType, ignoreCase: true, out VehicleType parsedVehicleType))
            throw new Exception("Vehicle Type must be a 'Car', 'Bus' or 'Bicycle'");

        if (!FormData.TryGetValue("Make", out string? vehicleMake))
            throw new Exception("Vehicle Make is a required field");

        if (!FormData.TryGetValue("Color", out string? vehicleColor))
            throw new Exception("Vehicle Color is a required field");

        if (!FormData.TryGetValue("VIN", out string? vehicleVIN) && (parsedVehicleType == VehicleType.Car || parsedVehicleType == VehicleType.Bus))
            throw new Exception("VIN is a required field for Car and Bus");

        return new ParkNewVehicleRequestDTO(
            make: vehicleMake,
            color: vehicleColor,
            // ToDo: fix this
            vin: vehicleVIN ?? "",
            type: parsedVehicleType);


    }

    public override async Task Submit()
    {
        var parsedFormData = ParseFormData(FormData) ?? throw new Exception($"Form data is incomplete: {FormData}");
        CancellationToken stoppingToken = new();
        await _request.PublishAsync(new ParkNewVehicleRequestEvent(parsedFormData), stoppingToken);
    }
}
 