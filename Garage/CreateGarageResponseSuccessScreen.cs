using Garage.UI;

namespace Garage
{
    internal class CreateGarageResponseSuccessScreen(
        MainMenu mainMenu
    )
    {
        public void RenderWithProps(CreateGarageResponseDTO props)
        {
            ConsoleUI.Clear();
            ConsoleUI.WriteLineInfo("New Garage created:\n");
            if (props != null)
            {
                var (name, capacity) = props;

                ConsoleUI.WriteLine($"Name: '{name}'");
                ConsoleUI.WriteLine($"Capacity: {capacity}");
            }
            ConsoleUI.Continue();
            mainMenu.ResetMenuSelection();
            mainMenu.Render();
        }
    }
}
