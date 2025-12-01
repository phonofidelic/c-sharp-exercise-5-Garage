using Garage.Library;
using Garage.UI;
using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class ListVehiclesView(
        IApplicationRequest request,
         ListVehiclesMenu listParkedVehiclesMenu) : IRender, IRenderAsync
    {
        public void Render()
        {
            // CancellationToken stoppingToken = new();
            // _ = RequestVehiclesAsync(stoppingToken);
            
            bool result = request.TryPublish(new ListParkedVehiclesRequestEvent(
               new ListParkedVehiclesDTO([])));

            if (!result)
                throw new Exception("Could not publish event");

            listParkedVehiclesMenu.Render();
        }

        public Task RenderAsync()
        {
            throw new NotImplementedException();
        }

        private async Task RequestVehiclesAsync(CancellationToken stoppingToken)
        {
            
            await request.PublishAsync(new ListParkedVehiclesRequestEvent(
               new ListParkedVehiclesDTO([])), stoppingToken);
            listParkedVehiclesMenu.Render();
        }
    }
}
