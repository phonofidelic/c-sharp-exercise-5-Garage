namespace Garage.Library
{
    public abstract class ApplicationEvent()
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public object Payload { get; init; }
    }
}

