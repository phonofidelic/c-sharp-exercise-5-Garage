namespace Garage.Library
{
    public interface IApplicationEvent
    {
        Guid Id { get; init; }
        //Enum Type { get; init; }
    }

    //public abstract record ApplicationEvent(Guid Id, object Payload) : IApplicationEvent;
    public abstract class ApplicationEvent(Enum type, object payload)
        : IApplicationEvent
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Enum Type { get; private init; } = type;
        public object Payload { get; init; } = payload;

        //public static explicit operator ApplicationEvent<T>(CreateGarageRequestEvent v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

