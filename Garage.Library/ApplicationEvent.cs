namespace Garage.Library
{
    public abstract class ApplicationEvent()
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public object Payload { get; init; }

        public ApplicationEvent? Response;

        public void Handle(Func<ApplicationEvent> response)
        {
            Response = response();
        }

        // ToDo: Implement SetNext()
    }
}

