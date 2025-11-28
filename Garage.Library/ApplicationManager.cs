namespace Garage.Library
{
    public class ApplicationManager() : IApplicationManager
    {
        private List<IApplication> _applications = [];

        public void Start()
        {
            Parallel.ForEach(_applications, (app) => app.Run());
        }

        public void Add<TEvent>(IApplication app) where TEvent : ApplicationEvent
        {
            // ToDo: register event handlers for each application here?
            _applications.Add(app);
        }

        public void Route(ApplicationEvent @event)
        {
            Parallel.ForEach(_applications, (app) => app.Handle(@event));
        }
    }
}
