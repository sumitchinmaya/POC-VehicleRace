using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POC_VehicleRace.Entities;
using POC_VehicleRace.Models;
using POC_VehicleRace.Models.Enums;
using POC_VehicleRace.Respositories.Contract.Repository;
using POC_VehicleRace.Respositories.IContract.IRepository;
using POC_VehicleRace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_VehicleRace.Tests
{
    [TestClass]
    public class TrackServiceTests
    {
        #region Global Declaration

        private IVehicleRaceService vehicleRaceService;
        private IList<VehicleDto> mockdata;
        private Mock<IVehicleRepository> mockRepository;
        Guid mockedVehicleId;

        #endregion

        #region Test Setup

        private void Setup()
        {
            mockedVehicleId = Guid.NewGuid();
            mockdata = new List<VehicleDto>()
            {
                //Prepaire vehicle data for mock
                new VehicleDto()
                {
                    Id = mockedVehicleId,
                    Name = "Ford Mustang",
                    Break = true,
                    TowStrap = true,
                    Lift = 5,
                    Type=VehicleTypes.Car,
                    Image= "car.PNG",
                    CreatedDate=DateTime.Now
                },
                 new VehicleDto ()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mercedes",
                    Break = true,
                    TowStrap = true,
                    Lift = 5,
                    Type=VehicleTypes.Truck,
                    Image= "truck.PNG",
                    CreatedDate=DateTime.Now
                },
            };
            //Mock repository
            mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup(x => x.maxVehicleOnTrack).Returns(() => 5);
            vehicleRaceService = new VehicleRaceService(mockRepository.Object);
        }
        #endregion

        

        #region Vehicle inspection test cases
        [TestMethod]
        public void ShouldFailWhenVehicleWIthoutTowStrap()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Add(It.IsAny<Vehicle>()));

            var mockVehicleDto = mockdata[0];
            mockVehicleDto.TowStrap = false;

            //Act
            var actualResult = vehicleRaceService.AddVehicles(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.InspectionFail, actualResult);
        }
        [TestMethod]
        public void ShouldFailWhenTruckLiftMoreThanExpectation()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Add(It.IsAny<Vehicle>()));

            var mockVehicleDto = mockdata[1];
            mockVehicleDto.Lift = 6;

            //Act
            var actualResult = vehicleRaceService.AddVehicles(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.InspectionFail, actualResult);
        }
        [TestMethod]
        public void ShouldFailWhenCarWithTireWearMoreThanLimit()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Add(It.IsAny<Vehicle>()));

            var mockVehicleDto = mockdata[0];
            mockVehicleDto.TireWear = 86;

            //Act
            var actualResult = vehicleRaceService.AddVehicles(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.InspectionFail, actualResult);
        }

        #endregion


        
    }
}
