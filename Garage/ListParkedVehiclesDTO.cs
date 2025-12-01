using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public record ListParkedVehiclesDTO(
        string Make,
        string VIN,
        string Color)
        : VehicleProperties(
            Make,
            VIN,
            Color)
    { };
}
