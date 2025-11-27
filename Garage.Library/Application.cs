namespace Garage.Library
{
    public abstract class Application(string name, IEventBus eventBus) : IApplication
    {
        public string Name { get; } = name;
        protected IEventBus _eventBus { get; } = eventBus;
        public abstract ApplicationStatus Run();

    }
}
