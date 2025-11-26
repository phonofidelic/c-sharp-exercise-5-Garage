using Garage.UI;
using System.Threading.Channels;

namespace Garage
{
    internal class ApplicationManager()
    {
        private List<Application> _applications = [];
        public ApplicationMessage? CurrentMessage { get; set; } = null;

        async public void Start(Channel<ApplicationMessage> channel)
        {
            // Create application instances to run with the manager
            /* TodDo:
            * Status status;
            * GarageApplication garageApp = new(config);
            * AddApplication(garageApp);
            */
            // Todo: GarageConsoleUIApplication?
            //GarageUIApplication client = new("Garage UI client application", channel.Writer);
            //GarageApplication client2 = new("Garage backend application", channel.Reader);
            //Add(client);
            //client2.LogColor = ConsoleColor.DarkMagenta;
            //Add(client2);

            // ToDo: Learn how to run multiple apps in parallel
            foreach (Application app in _applications)
            {
                try
                {
                    Run(app);
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
            }
            await ConsumeAsync(channel.Reader);
        }

        //public async ValueTask ProduceAsync(ChannelWriter<ApplicationMessage> writer, Application app)
        //{
        //    while (await writer.WaitToWriteAsync())
        //    {
        //        if (Status == null) Status = new(1);
        //        ApplicationStatus tempStatus = app.Run();

        //        if (writer.TryWrite(item: tempStatus))
        //        {
        //            Status = tempStatus;
        //        }

        //        await Task.Delay(TimeSpan.FromMilliseconds(10));
        //    }
        //    writer.Complete();
        //}

        public async ValueTask ConsumeAsync(ChannelReader<ApplicationMessage> reader)
        {
            while (await reader.WaitToReadAsync())
            {
                while (reader.TryRead(out ApplicationMessage newMessage))
                {
                    Console.WriteLine($"NEW MESSAGE: {newMessage}");
                    CurrentMessage = newMessage;
                }
            }
        }

        private static void Run(Application app)
        {
            ApplicationStatus status;
            do
            {
                try
                {
                    // ConsoleUI.WriteLineInfo($"\nStarting application '{app.Name}'");
                    app.Log($"Starting application '{app.Name}'");
                    status = app.Run();
                }
                catch (Exception ex) {
                    // Unhandled exception
                    app.LogException(new Exception($"Uncaught exception occurred in '{app.Name}':\n\n'{ex.Message}'\n\n{ex.StackTrace}"));
                    status = new(-1);
                } 
                finally
                {
                    // End application
                    app.Log($"Shutting down application '{app.Name}'");
                    status = new(0);
                    // _applications.Remove(app);
                }
            } while (status.Code > 0);

            if (status.Code < 0 && status.Exception != null)
                app.LogException(new Exception($"Unhandled exception occurred in '{app.Name}' :\n{status.Exception.Message}"));
        }

        private void Add(Application app)
        {
            _applications.Add(app);
        }

        private static void LogException(Exception exception)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            ConsoleUI.Write("MANAGER ERROR:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleUI.WriteLine($" {exception.Message}");
            Console.ResetColor();
        }
    }

    public static class ApplicationExtensions
    {
        public static void Log(this Application app, string message) {
            Console.BackgroundColor = app.LogColor;
            ConsoleUI.Write($"{app.LogName}:");
            Console.ResetColor();
            ConsoleUI.WriteLine($" {message}");
        }

        public static void LogException(this Application app, Exception exception) {
            Console.BackgroundColor = app.LogColor;
            ConsoleUI.Write($"{app.LogName}:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleUI.WriteLine($" {exception.Message}");
            Console.ResetColor();
        }
    }
}
