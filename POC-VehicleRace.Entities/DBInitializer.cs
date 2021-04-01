using POC_VehicleRace.Models;
using System;
using System.Collections.Generic;

namespace POC_VehicleRace.Entities
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            var vehicles = new List<Vehicle>()
            {
                //Prepare vehicle data for migration
                new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vehicle1",
                    Type=VehicleTypes.Car,
                    Break = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    CreatedDate=DateTime.Now
                },
                 new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vehicle2",
                    Break = true,
                    Type=VehicleTypes.Car,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    CreatedDate=DateTime.Now
                },
                  new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vehicle3",
                    Type=VehicleTypes.Car,
                    Break = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    CreatedDate=DateTime.Now
                },
                   new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vehicle4",
                    Type=VehicleTypes.Car,
                    Break = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    CreatedDate=DateTime.Now
                },
                    new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vehicle5",
                    Type=VehicleTypes.Car,
                    Break = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    CreatedDate=DateTime.Now
                },
            };
            vehicles.ForEach(vehicle => context.Vehicles.Add(vehicle));

            base.Seed(context);
        }
    }
}
