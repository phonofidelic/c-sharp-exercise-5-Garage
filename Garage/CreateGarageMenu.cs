using Garage.Library;
using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class CreateGarageMenu : IRender
    {
        public IApplicationRequest _request;

        public CreateGarageMenu(IApplicationRequest request)
        {
            _request = request;
        }

        public void Render()
        {
            _ = RenderAsync();
        }
        private Task RenderAsync()
        {
            ConsoleUI.WriteLine("NewGarage rendered");
            CancellationToken stoppingToken = new();
            CreateGarageRequestEvent garageCreatedEvent = new(new("My new garage", 50));
            //await eventBus.PublishAsync(garageCreatedEvent, cancellationToken);
            return _request.Publish(garageCreatedEvent, stoppingToken);
        }
    }
}
