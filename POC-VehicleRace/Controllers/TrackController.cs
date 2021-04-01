using POC_VehicleRace.Models.Enums;
using POC_VehicleRace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_VehicleRace.Controllers
{
    public class TrackController : Controller
    {

        private readonly IVehicleRaceService _vehicleRaceService;
        public TrackController(IVehicleRaceService vehicleRaceService)
        {
            _vehicleRaceService = vehicleRaceService;
        }
        // GET: Track
        public ActionResult Index()
        {
            return View(_vehicleRaceService.GetVehicles());
        }
        public PartialViewResult GetVehicle()
        {
            return PartialView("Vehicle", _vehicleRaceService.GetVehicles());
        }
        [HttpPost]
        public Response RemoveVehicleFromTrack(Guid vehicleId)
        {
            return _vehicleRaceService.RemoveVehicles(vehicleId);
        }
    }
}