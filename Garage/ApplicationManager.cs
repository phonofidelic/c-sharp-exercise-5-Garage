using Garage.UI;

namespace Garage
{
    internal class ApplicationManager
    {
        public int? Selection { get; private set; } // ToDo: remove
        
        private List<Application> _applications = [];
        public ApplicationManager()
        {
            Selection = null;
        }

        internal void Run()
        {
            // TodDo: This should be inside of an Application instance
            /*
             * Status status;
             * GarageApplication garageApp = new();
             * garageAppStatus = garageApp.Start(config);
             * 
             * UIApplication clientApp = new();
             * clientAppStatus clientApp.Start()
             */

            GarageUIApplication client = new();
            AddApplication(client);

            foreach (Application app in _applications) {
                app.Start();
            }
        }

        private void AddApplication(Application application)
        {
            _applications.Add(application);
        }
    }
}