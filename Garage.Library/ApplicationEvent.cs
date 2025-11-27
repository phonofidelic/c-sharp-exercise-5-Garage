namespace Garage.Library
{
    public abstract class ApplicationEvent(Enum type)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Enum Type { get; private init; } = type;
        public object Payload { get; init; }

        public ApplicationEvent? Response;

        public void Handle(Func<ApplicationEvent> response)
        {
            Response = response();
        }
    }
}

