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
            GarageUIApplication client = new("Garage UI client application");
            Add(client);

            foreach (Application app in _applications)
            {
                Run(app);
            }
        }

        private static void Run(Application app)
        {
            ApplicationStatus status = new(1);
            do
            {
                try
                {
                    status = app.Run();
                }
                catch (Exception ex) {
                    // Unhandled exception
                    ConsoleUI.WriteException($"\nUncaught exception occurred in ' {app.Name}' :\n :\n{ex.Message}"); ;
                } finally
                {
                    // End application
                    ConsoleUI.WriteLineInfo($"Shutting down application '{app.Name}'");
                }
            } while (status.Code > 0);

            if (status.Code < 0 && status.Exception != null)
                ConsoleUI.WriteException($"\nUnhandled exception occurred in '{app.Name}' :\n{status.Exception.Message}");
        }

        private void Add(Application app)
        {
            _applications.Add(app);
        }
    }
}