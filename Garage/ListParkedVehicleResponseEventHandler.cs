using System;
using Garage.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garage
{  
    internal class ListParkedVehicleResponseEventHandler(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<ListParkedVehicleResponseEventHandler> logger)
        : ApplicationEventHandler<ListParkedVehiclesResponseEvent>(logger)
    {
        public ListParkedVehiclesResponseDTO? Props { get; private set;} = null;

        protected override void _handle<TEvent>(TEvent @event)
        {
            logger.LogDebug("Processing data for event: {Event}", @event);
            ListParkedVehiclesResponseDTO parsedPayload = (ListParkedVehiclesResponseDTO)@event.Payload;
            Props = parsedPayload;
            logger.LogDebug("Props set: {}", Props);

            // Get UI components to render
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            var listParkedVehiclesMenu = scope.ServiceProvider.GetRequiredService<ListVehiclesMenu>();

            // Render the updated menu
            listParkedVehiclesMenu.Render();
        }
        public override void SetNext(IHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}

