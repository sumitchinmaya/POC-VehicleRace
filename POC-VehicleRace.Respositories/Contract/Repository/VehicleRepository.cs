using POC_VehicleRace.Entities;
using POC_VehicleRace.Models;
using POC_VehicleRace.Respositories.IContract.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_VehicleRace.Respositories.Contract.Repository
{
    public class VehicleRepository:BaseRepository<Vehicle>,IVehicleRepository
    {
        public int maxVehicleOnTrack { get; set; }
        public EFContext Database { get; }
        public VehicleRepository(EFContext _database) : base(_database)
        {
            Database = _database;
        }
    }
}
