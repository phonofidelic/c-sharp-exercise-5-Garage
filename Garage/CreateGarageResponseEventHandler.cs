using Garage.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garage
{
    internal class CreateGarageResponseEventHandler(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<CreateGarageResponseEventHandler> logger)
        : ApplicationEventHandler<CreateGarageResponseEvent>
    {
        public CreateGarageResponseDTO? Props { get; private set; } = null;
        protected override void _handle(CreateGarageResponseEvent @event)
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
        public override void SetNext(IHandler<CreateGarageResponseEvent> handler)
        {
            throw new NotImplementedException();
        }
    }
}