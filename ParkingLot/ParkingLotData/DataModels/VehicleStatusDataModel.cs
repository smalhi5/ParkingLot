using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotData.DataModels
{
    public class VehicleStatusDataModel
    {
        public int VecicleId { get; set; }
        public int ParkId { get; set; }
        public string Status { get; set; }
    }
}
