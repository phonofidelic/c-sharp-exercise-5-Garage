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
        private IApplicationRequest _request;
        private readonly ILogger<CreateGarageMenu> _logger;
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
            CancellationToken stoppingToken = new();
            CreateGarageRequestEvent garageCreatedEvent = new(new CreateGarageRequestDTO("My new garage", 50));
            await _request.PublishAsync(garageCreatedEvent, stoppingToken);
        }
    }
}
