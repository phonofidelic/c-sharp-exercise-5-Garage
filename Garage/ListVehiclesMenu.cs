using System;
using Garage.Library;
using Garage.UI;

namespace Garage;

internal class ListVehiclesMenu: ConsoleMenu
{
    public ListVehiclesMenu()
        : base(
    name: "Parked Vehicles",
    displayName: "Parked Vehicles",
    description: "Showing all vehicles currently parked in the garage:",
    menuItems: [],
    selectionPrompt: "Press 'Esc.' to go back")
    {}

    // public override MenuSelection? Selection { get; protected set; }
    // protected override Exception? MenuException { get; set; }
}
