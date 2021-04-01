using POC_VehicleRace.Models;
using POC_VehicleRace.Models.Enums;
using POC_VehicleRace.Respositories.IContract.IRepository;
using POC_VehicleRace.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace POC_VehicleRace
{
    public class VehicleRaceService:IVehicleRaceService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly int maxVehicleOnTrack = 0;
        public VehicleRaceService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            maxVehicleOnTrack = _vehicleRepository.maxVehicleOnTrack == 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["MaxVehicleOnTrack"]) 
                : vehicleRepository.maxVehicleOnTrack;
        }
        public Response AddVehicles(VehicleDto vehicle)
        {
            try
            {
                //Check for track overload
                bool checkTrackOverload = _vehicleRepository.FindAll().Count() >= maxVehicleOnTrack ? true : false;

                //Vehicle inspection
                if (!Inspection(vehicle))
                    return Response.InspectionFail;

                //Process for saving in database
                var vehicleDetails = Vehicle.GetVehicleObj(vehicle.Name, vehicle.Type, vehicle.Break,vehicle.TowStrap,  vehicle.Lift, vehicle.TireWear, vehicle.Image);
                
                //In case of track overloaded
                if (checkTrackOverload)
                    return Response.Overloaded;
                _vehicleRepository.Add(vehicleDetails);
                _vehicleRepository.Database.SaveChanges();
                return Response.Inserted;
            }
            catch (Exception ex )
            {
                return Response.None;
            }
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleRepository.FindAll();
        }

        public Response RemoveVehicles(Guid vehicleId)
        {
            try
            {
                _vehicleRepository.Delete(vehicleId);
                _vehicleRepository.Database.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Response.Deleted;
        }

        public bool Inspection(VehicleDto vehicleDto)
        {

            //TowStrap should be true for both truck and car
            if (vehicleDto.TowStrap == true)
            {
                bool validVehicle = false;
                switch(vehicleDto.Type)
                {
                    case VehicleTypes.Car:
                        validVehicle = (vehicleDto.TireWear < 85);
                        break;
                    case VehicleTypes.Truck:
                        validVehicle = (vehicleDto.Lift <= 5);
                        break;
                }
                return validVehicle;
            }
            return false;

        }
    }
}