using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace Garage
{
    internal class GarageUIApplication(string name, ChannelWriter<ApplicationMessage> writer) : Application(name, writer)
    {
        public override ApplicationStatus Run()
        {
            bool exitApplication = false;
            
            MainMenu mainMenu = new(writer);

            do
            {
                try
                {
                    mainMenu.Render();
                    //Writer!.TryWrite(new(1));
                } catch (Exception ex)
                {
                    //Writer!.TryWrite(new(-1, ex));
                    return new ApplicationStatus(-1, ex);
                }
                ConsoleUI.WriteLineInfo("Press 'Esc.' to quit the application");
                exitApplication = ConfirmExit(() => ConsoleUI.ReadKey(intercept: true), out _);
            } while(!exitApplication);

            //Writer!.TryWrite(new(0));
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
