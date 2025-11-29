namespace Garage.Library
{
    public interface IApplicationManager
    {
        public void Add<TEvent>(IApplication app) where TEvent : ApplicationEvent;
        public void Add(IHandler handler);
        public void Start();
        public void Handle(ApplicationEvent @event);
    }
}