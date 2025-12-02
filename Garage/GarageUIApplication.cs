using System.Runtime.CompilerServices;
using Garage.Library;
using Garage.UI;

namespace Garage
{
    internal class GarageUIApplication(
        MainMenu mainMenu
        ) 
        : Application("Garage UI"), IUI
    {
        public override ApplicationStatus Run()
        {
            bool exitApplication = false;
            
            do
            {
                try
                {
                    mainMenu.ResetMenuSelection();
                    mainMenu.Render();
                } catch (Exception ex)
                {
                    return new ApplicationStatus(-1, ex);
                }
                exitApplication = ConfirmExit(() => ConsoleUI.ReadKey(intercept: true), out _);
            } while((mainMenu.Selection?.Option != null) &&  !exitApplication);

            return new ApplicationStatus(0);
        }

        private bool ConfirmExit(Func<ConsoleKeyInfo> answer, out ConsoleKeyInfo nextKeyInfo)
        {
            ConsoleUI.Clear();
            ConsoleUI.WriteLine($"\nAre you sure you want to quit {Name}?");
            ConsoleUI.Write("\n\n\tPress ");
            ConsoleUI.WriteColor("\"Y\" to confirm", ConsoleColor.Green);
            ConsoleUI.Write(", any other key to ");
            ConsoleUI.WriteColor("cancel", ConsoleColor.Red);
            nextKeyInfo = answer();
            return nextKeyInfo.Key == ConsoleKey.Y;
        }
    }   
}
