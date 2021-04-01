using POC_VehicleRace.Helper;
using POC_VehicleRace.Models;
using POC_VehicleRace.Models.Enums;
using POC_VehicleRace.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_VehicleRace.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRaceService _vehicleRaceService;

        public VehicleController(IVehicleRaceService vehicleRaceService)
        {
            _vehicleRaceService = vehicleRaceService;
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDto vehicleDto)
        {
            //Vehicle Inspection
            if (!_vehicleRaceService.Inspection(vehicleDto))
            {
                ModelState.AddModelError(nameof(vehicleDto.ResponseMessage), Utility.GetValueFromResources(Keys.InspectionFailMessage));
            }
            if (ModelState.IsValid)
            {

                //Process image file
                var image = vehicleDto.ImageFile;

                if (image?.ContentLength > 0)
                {
                    //To Get File Extension  
                    string fileExtension = Path.GetExtension(image.FileName);

                    //Add Current Date To Attached File Name  
                    string fileName = Guid.NewGuid() + fileExtension;
                    string folderPath = Path.Combine(Server.MapPath(Utility.GetValueFromResources(Keys.ImageLocation)), fileName);
                    image.SaveAs(folderPath);
                    vehicleDto.Image = fileName;
                }
                //Save record in db
                Response response = _vehicleRaceService.AddVehicles(vehicleDto);
                if (response == Models.Enums.Response.Inserted)
                    ViewBag.Success = Utility.GetValueFromResources(Keys.SuccessMessage);
                else
                    ModelState.AddModelError(nameof(vehicleDto.ResponseMessage), Utility.GetValueFromResources(Keys.OverloadMessage));
            }

            return View();
        }

       
        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehicle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
