namespace Garage.Library
{
    public abstract class ApplicationEvent(Enum type, object payload)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Enum Type { get; private init; } = type;
        public object Payload { get; init; } = payload;
    }
}

