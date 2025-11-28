namespace Garage.Library
{
    public interface IHandler<TEvent> where TEvent : ApplicationEvent
    {
        void Handle(TEvent @event);
        void SetNext(IHandler<TEvent> handler);
    }
}