using System;
using Garage.UI;

namespace Garage;

internal class RemoveVehicleMenu() : ConsoleMenu
(
    name: "Remove vehicle menu",
    displayName: "Remove vehicle",
    description: "Select a vehicle to remove from the garage:",
    [
        new("Vehicle ABC-123 (car)"),
        new("Vehicle DEF-456 (bus)"),
        new("Vehicle GHI-789 (bike)")
    ],
    selectionPrompt: "Select an option from the menu.\nPress 'Esc.' to go back")
{
    public override MenuSelection? Selection { get; protected set; }
    protected override Exception? MenuException { get; set; }
}
