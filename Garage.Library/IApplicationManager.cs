namespace Garage.Library
{
    public interface IApplicationManager
    {
        public void Add<TEvent>(IApplication app) where TEvent : ApplicationEvent;
        public void Start();

        public void Route(ApplicationEvent @event);
    }
}