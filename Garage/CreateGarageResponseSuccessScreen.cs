using Garage.UI;

namespace Garage
{
    internal class CreateGarageResponseSuccessScreen(
        MainMenu mainMenu)
    {
        public void RenderWithProps(CreateGarageResponseDTO props)
        {
            ConsoleUI.Clear();
            ConsoleUI.WriteLineInfo("New Garage created:\n");
            if (props != null)
            {
                var (name, capacity, vehicleIds) = props;

                ConsoleUI.WriteLine(name);
                ConsoleUI.WriteLine($"Capacity, {capacity}");
                ConsoleUI.WriteLine("Vehicles:");
                foreach (Guid vehicleId in vehicleIds)
                {
                    ConsoleUI.WriteLine($"\n\t{vehicleId}");
                }
            }
            ConsoleUI.Continue();
            mainMenu?.Render();
        }
    }
}
