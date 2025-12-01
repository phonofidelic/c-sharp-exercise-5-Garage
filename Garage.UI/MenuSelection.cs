using System;

namespace Garage.UI;

public record MenuSelection
{
    public int Option { get; private init; }
    public MenuListItem? Item { get; private init; }
    public MenuSelection(int option, MenuListItem item)
    {
        Option = option;
        Item = item;
    }
    public MenuSelection(int option)
    {
        Option = option;
        Item = null;
    }
}
