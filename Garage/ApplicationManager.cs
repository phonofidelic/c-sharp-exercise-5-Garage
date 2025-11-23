using Garage.UI;

namespace Garage
{
    internal class ApplicationManager()
    {
        private List<Application> _applications = [];

        public void Start()
        {
            // Create application instances to run with the manager
            /* TodDo:
            * Status status;
            * GarageApplication garageApp = new(config);
            * AddApplication(garageApp);
            */
            // Todo: GarageConsoleUIApplication?
            GarageUIApplication client = new("Garage UI client application");
            GarageApplication client2 = new("Garage backend application");
            Add(client);
            client2.LogColor = ConsoleColor.DarkMagenta;
            Add(client2);

            // ToDo: Learn how to run multiple apps in parallel
            foreach (Application app in _applications)
            {
                try
                {
                    Run(app);
                } catch (Exception ex)
                {
                    LogException(ex);
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
