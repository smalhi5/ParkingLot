using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotAPI.Interfaces;
using ParkingLotAPI.Models;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {

        private readonly IParkingLotService _parkingLotService;

        public ParkingLotController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        [HttpGet]
        [Route("ParkingLotStatus")]
        public IActionResult ParkingLotStatus()
        {
            string response = _parkingLotService.ParkingLotStatus();
            if (response is null)
            {
                return BadRequest("Something went wrong getting the data.");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("TotalParking")]
        public IActionResult TotalParking()
        {
            string response = _parkingLotService.TotalParking();
            if (response is null)
            {
                return BadRequest("Something went wrong getting the data.");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("ParkingSpotStatus")]
        public IActionResult ParkingSpotStatus(ParkingLotTypeRequestModel parkType)
        {
            if (parkType is null)
            {
                return BadRequest("No data was given");
            }
            string response = _parkingLotService.SpotsStatus(parkType);
            if (response is null)
            {
                return BadRequest("Something went wrong getting the data.");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("VehicleSpotTaken")]
        public IActionResult VehicleSpotTaken(VehicleTypeRequestModel vehicleType)
        {
            if (vehicleType is null)
            {
                return BadRequest("No data was given");
            }
            string response = _parkingLotService.SpotTakenByVehicleType(vehicleType);
            if (response is null)
            {
                return BadRequest("Something went wrong getting the data.");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVehicleByParkingId")]
        public IActionResult GetVehicleByParkingId(ParkingLotIdRequestModel parkingId)
        {
            if (parkingId is null)
            {
                return BadRequest("No data was given");
            }
            VehicleModel response = _parkingLotService.GetVehicleByParkId(parkingId);
            if (response is null)
            {
                return BadRequest("Something went wrong getting the data.");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVehicleByParkingName")]
        public IActionResult GetVehicleByParkingName(ParkingLotNameRequestModel parkingName)
        {
            if (parkingName is null)
            {
                return BadRequest("No data was given");
            }
            VehicleModel response = _parkingLotService.GetVehicleByParkName(parkingName);
            if (response is null)
            {
                return BadRequest("Something went wrong getting the data.");
            }
            return Ok(response);
        }
    }
}
