using POC_VehicleRace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_VehicleRace.Respositories.IContract.IRepository
{
    public interface IVehicleRepository:IBaseRepository<Vehicle>
    {

        int maxVehicleOnTrack { get; set; }
    }
}
