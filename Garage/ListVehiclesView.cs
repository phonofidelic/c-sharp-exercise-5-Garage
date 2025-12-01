using Garage.Library;
using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class ListVehiclesView(IApplicationRequest request) : IRender
    {
        public void Render()
        {
            _ = RequestVehiclesAsync();
        }

        private async Task RequestVehiclesAsync()
        {
            CancellationToken stoppingToken = new();
            await request.Publish(new ListParkedVehiclesRequestEvent(
               new ListParkedVehiclesDTO([])), stoppingToken);
        }
    }
}
