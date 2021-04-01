using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_VehicleRace.Models
{
    public class Vehicle
    {
        public static Vehicle GetVehicleObj(string _name, VehicleTypes _type, bool _break, bool _towStrap,  int _lift, int? _tireWear, string _imagePath)
        {
            return new Vehicle()
            {
                Id = Guid.NewGuid(),
                Name = _name,
                Type = _type,
                Break = _break,
                TowStrap = _towStrap,
                Lift = _lift,
                TireWear = _tireWear,
                Image = _imagePath,
                CreatedDate = DateTime.Now
            };
        }
        public Guid Id { get; set; }
        public VehicleTypes Type { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Break { get; set; }

        public bool TowStrap { get; set; }
        [RequireForVehicleTypes]
        public int Lift { get; set; }

        public string Image { get; set; }

        public int? TireWear { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
