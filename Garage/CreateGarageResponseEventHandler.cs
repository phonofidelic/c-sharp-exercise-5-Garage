using Garage.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class CreateGarageResponseEventHandler(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<CreateGarageResponseEventHandler> logger)
        : ApplicationEventHandler<CreateGarageResponseEvent>(logger)
    {
        public CreateGarageResponseDTO? Props { get; private set; } = null;
        protected override void _handle<TEvent>(TEvent @event)
        {
            logger.LogInformation("Processing data for event: {Event}", @event);
            CreateGarageResponseDTO parsedPayload = (CreateGarageResponseDTO)@event.Payload;
            Props = parsedPayload;
            logger.LogInformation("Props set: {}", Props);

            // Get UI components to render
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            var successScreen = scope.ServiceProvider.GetRequiredService<CreateGarageResponseSuccessScreen>();
            
            // Render UI for new Garage
            successScreen.RenderWithProps(Props);

            // Reset handler state
            Props = null;
        }
        public override void SetNext(IHandler handler)
        {
            throw new NotImplementedException();
        }

        //public override void Handle<TEvent>(TEvent @event)
        //{
        //    // Check if the concrete handler can handle the event
        //    logger.LogInformation("Checking if handler can handle event: {Event}, {CanHandle}", @event, @event.GetType() == typeof(CreateGarageResponseEvent));
        //    logger.LogInformation("Handler event type: {EventType}", typeof(CreateGarageResponseEvent));
        //    logger.LogInformation("Target event type: {EventType}", @event);
        //    if (@event.GetType() == typeof(CreateGarageResponseEvent))
        //    {
        //        _handle(@event);
        //    }
        //}
    }
}