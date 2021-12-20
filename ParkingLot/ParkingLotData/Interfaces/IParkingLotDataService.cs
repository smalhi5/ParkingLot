using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotData.DataModels;

namespace ParkingLotData.Interfaces
{
    public interface IParkingLotDataService
    {
        public List<ParkingLotDataModel> GetParkingLots();
        public List<ParkingLotTypeDataModel> GetParkingLotType();
        public List<VehicleDataModel> GetVehicle();
        public List<VehicleStatusDataModel> GetVehicleStatus();
    }
}
