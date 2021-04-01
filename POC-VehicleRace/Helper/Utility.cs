using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_VehicleRace.Helper
{
    public static class Utility
    {
        public static string GetValueFromResources(string resourcesKey)
        {
            return RacingVehicle.ResourceManager.GetString(resourcesKey);
        }
    }
}