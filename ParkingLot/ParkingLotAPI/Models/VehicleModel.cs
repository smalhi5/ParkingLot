using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotData.DataModels;

namespace ParkingLotAPI.Models
{
    public class VehicleModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }

        public void Map(VehicleDataModel vehicle)
        {
            Make = vehicle.Make;
            Model = vehicle.Model;
            VehicleType = vehicle.Type;
        }
    }
}
