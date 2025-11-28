namespace Garage.Library
{
    public abstract class Application<TEvent>(
        string name, 
        IHandler<TEvent> handler) 
        : IApplication where TEvent : ApplicationEvent
    {
        public string Name { get; } = name;
        protected IHandler<TEvent> _handler { get; set; } = handler;
        // ToDo: Remove _eventBus?
        public abstract ApplicationStatus Run();

        public void Handle(ApplicationEvent @event)
        {
            //_handler.Handle((TEvent)@event);
            if (@event.GetType() == typeof(TEvent))
            {
                _handler.Handle((TEvent)@event);
            }
        }


        //public void SetNext(IHandler<TEvent> handler)
        //{
        //    _handler.SetNext(handler);
        //}
    }
}
