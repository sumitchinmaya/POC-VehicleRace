using POC_VehicleRace.Models;
using POC_VehicleRace.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_VehicleRace.Services
{
    public interface IVehicleRaceService
    {
        IEnumerable<Vehicle> GetVehicles();
        Response AddVehicles(VehicleDto vehicle);
        Response RemoveVehicles(Guid vehicleId);
        bool Inspection(VehicleDto vehicleDto);
    }
}