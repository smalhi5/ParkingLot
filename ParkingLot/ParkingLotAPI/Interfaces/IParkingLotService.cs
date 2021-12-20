using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotAPI.Models;

namespace ParkingLotAPI.Interfaces
{
    public interface IParkingLotService
    {
        public string ParkingLotStatus();
        public string TotalParking();
        public string SpotsStatus(ParkingLotTypeRequestModel parkingType);
        public string SpotTakenByVehicleType(VehicleTypeRequestModel vehicleType);
        public VehicleModel GetVehicleByParkId(ParkingLotIdRequestModel parkingId);
        public VehicleModel GetVehicleByParkName(ParkingLotNameRequestModel parkingName);
    }
}
