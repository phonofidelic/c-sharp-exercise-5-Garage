using Garage.Library;
using Garage.UI;
using Microsoft.Extensions.Logging;
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
        private ILogger<CreateGarageMenu> _logger;

        public CreateGarageMenu(IApplicationRequest request, ILogger<CreateGarageMenu> logger)
        {
            _request = request;
            _logger = logger;
        }

        public void Render()
        {
            _ = RenderAsync();
        }
        private async Task RenderAsync()
        {
            ConsoleUI.WriteLine("NewGarage rendered");
            CancellationToken stoppingToken = new();
            CreateGarageRequestEvent garageCreatedEvent = new(new("My new garage", 50));
            await _request.Publish(garageCreatedEvent, stoppingToken);
            //ConsoleUI.WriteLine($"New garage created response: {garageCreatedEvent.Response}");
            _logger.LogInformation("New garage created response: {Response}", garageCreatedEvent.Response);
        }
    }
}
