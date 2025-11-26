using Garage.Library;
using Garage.UI;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace Garage;


internal class MainMenu(IEventBus eventBus) : ConsoleMenu(
    name: "Main menu",
    description: "Use the menu to make a selection:",
    menuListDtoItems: [
                new(
                    name: "Create new Garage",
                    children: new NewGarage(eventBus)
                ),
                new(
                    name: "List parked vehicles",
                    children: new ListVehiclesMenu()
                ),
                new(
                    name: "Park a new vehicle",
                    children: new ParkNewVehicleMenu()
                ),
                new(
                    name: "Remove a parked vehicle",
                    children: new RemoveVehicleMenu()
                )
            ],
    selectionPrompt: "Select an option from the menu. \nPress 'Esc.' to quit the application"
    )

{
}

internal class NewGarage(
    //IGarageStore store, 
    IEventBus eventBus) : IRender
{
    public async void Render() {
        ConsoleUI.WriteLine("NewGarage rendered");
        //MessageQueue queue = new();
        //EventBus bus = new(queue);
        //GarageCreatedApplicationEvent garageCreatedEvent = new(new());
        CancellationToken cancellationToken = new();
        CreateGarageRequestEvent garageCreatedEvent = new(new("My new garage"));
        await eventBus.PublishAsync(garageCreatedEvent, cancellationToken);
    }
}