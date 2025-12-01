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
         ListVehiclesMenu listParkedVehiclesMenu) : IRender
    {
        public void Render()
        {
            CancellationToken stoppingToken = new();
            _ = RequestVehiclesAsync(stoppingToken).ConfigureAwait(true);
            // listParkedVehiclesMenu.Render();
            // ConsoleUI.Loading();
            // task.RunSynchronously();
        }

        private async Task RequestVehiclesAsync(CancellationToken stoppingToken)
        {
            
            await request.PublishAsync(new ListParkedVehiclesRequestEvent(
               new ListParkedVehiclesDTO([])), stoppingToken);
        }
    }
}
