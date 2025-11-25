using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    internal class GarageUIApplication(string name) : Application(name)
    {
        public override ApplicationStatus Run()
        {
            bool exitApplication = false;
            
            MainMenu mainMenu = new();

            do
            {
                try
                {
                    mainMenu.Render();
                } catch (Exception ex)
                {
                    return new ApplicationStatus(-1, ex);
                }
                ConsoleUI.WriteLineInfo("Press 'Esc.' to quit the application");
                exitApplication = ConfirmExit(() => ConsoleUI.ReadKey(intercept: true), out _);
            } while(!exitApplication);

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
