using System;
using Garage.UI;
using Garage.Library;

namespace Garage;

internal class CreateNewGarageMenu(IEventBus eventBus): ConsoleMenu
(
    name: "Create a new Garage",
    description: "Initialize a new Garage by giving it a name and indicating its capacity.",
    menuListDtoItems: 
    [
        new("Name your garage"),
        new("Set garage size")
    ],
    selectionPrompt: "How many parking spaces are available in the garage?"
)
{}
