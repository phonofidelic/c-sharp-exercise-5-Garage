using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using Garage.Library;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class GarageUIApplication(
        CreateGarageResponseEventHandler handler, 
        IEventBus eventBus, 
        MainMenu mainMenu,
        ILogger<GarageUIApplication> logger) 
        : Application<CreateGarageResponseEvent>("Garage UI", handler, eventBus), IUI
    {
        public void Handle(CreateGarageResponseEvent @event)
        {
            //logger.LogInformation("ToDo: handle event: {Event}", @event);
            _handler.Handle(@event);
        }

        public void SetNext(IHandler<ApplicationEvent> handler)
        {
            throw new NotImplementedException();
        }

        public override ApplicationStatus Run()
        {
            bool exitApplication = false;
            
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
