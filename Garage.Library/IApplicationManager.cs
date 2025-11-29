namespace Garage.Library
{
    public interface IApplicationManager
    {
        public void Add(IApplication app);
        public void Add(IHandler handler);
        public void Start();
        public void Handle(ApplicationEvent @event);
    }
}