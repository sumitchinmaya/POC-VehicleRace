using POC_VehicleRace.Models;
using System;
using System.Collections.Generic;

namespace POC_VehicleRace.Entities
{
    public class DBMigration : System.Data.Entity.DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            var vehicles = new List<Vehicle>()
            {
                Vehicle.GetVehicleObj("Ford Mustang",VehicleTypes.Car,true,true,3,50,"car.png")
                ,
                Vehicle.GetVehicleObj("Mercedes",VehicleTypes.Truck,true,true,3,20,"truck.png")
                 ,
                  Vehicle.GetVehicleObj("Maybach",VehicleTypes.Truck,true,true,5,67,"car.png")
                ,

            };
            vehicles.ForEach(vehicle => context.Vehicles.Add(vehicle));

            base.Seed(context);
        }
    }
}
