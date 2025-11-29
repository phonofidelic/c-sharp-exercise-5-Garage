namespace Garage.Library
{
    public interface IHandler
    {
        void Handle<TEvent>(TEvent @event) where TEvent : ApplicationEvent;
         void SetNext(IHandler handler);
    }
}