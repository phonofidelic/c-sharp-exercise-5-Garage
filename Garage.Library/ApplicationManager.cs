namespace Garage.Library
{
    public class ApplicationManager() : IApplicationManager
    {
        private List<IApplication> _applications = [];
        private List<IHandler> _handlers = [];

        public void Start()
        {
            Parallel.ForEach(_applications, (app) => app.Run());
        }

        public void Add(IApplication app)
        {
            _applications.Add(app);
        }

        public void Add(IHandler handler)
        {
            _handlers.Add(handler);
        }

        public void Handle(ApplicationEvent @event) {
            Parallel.ForEach(_handlers, (handler) => handler.Handle(@event));
        }
    }
}
