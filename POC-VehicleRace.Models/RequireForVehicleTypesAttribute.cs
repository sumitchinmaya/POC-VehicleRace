using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_VehicleRace.Models
{
    public class RequireForVehicleTypesAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Vehicle vehicle = (Vehicle)validationContext.ObjectInstance;
            if (vehicle.Type == VehicleTypes.Truck && vehicle.Lift > 5)

                return new ValidationResult("Lift for truck can not be greater than 5.");

            return ValidationResult.Success;
        }
    }
}
