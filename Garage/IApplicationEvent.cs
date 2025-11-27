namespace Garage
{
    public interface IApplicationEvent
    {
        Guid Id { get; init; }
        //Enum Type { get; init; }
    }

    //public abstract record ApplicationEvent(Guid Id, object Payload) : IApplicationEvent;
    public abstract class ApplicationEvent<T>(T type, object payload)
        : IApplicationEvent where T : Enum
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public T Type { get; private init; } = type;
        public object Payload { get; init; } = payload;
    }
}

