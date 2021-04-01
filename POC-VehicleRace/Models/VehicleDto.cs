using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_VehicleRace.Models
{
    public class VehicleDto : Vehicle
    {
        public HttpPostedFileBase ImageFile { get; set; }
        public string ResponseMessage { get; set; }
    }
}