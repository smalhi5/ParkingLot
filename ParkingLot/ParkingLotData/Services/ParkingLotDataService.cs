using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ParkingLotData.Interfaces;
using ParkingLotData.DataModels;
using ParkingLotData.Services;

namespace ParkingLotData.Services
{
    public class ParkingLotDataService : IParkingLotDataService
    {

        private readonly ParkingLotContext _context;

        public ParkingLotDataService(ParkingLotContext context)
        {
            _context = context;
        }

        public List<ParkingLotDataModel> GetParkingLots()
        {
            List<ParkingLotDataModel> parkingLot = _context.ParkingLot.ToList();
            return parkingLot;
        }

        public List<ParkingLotTypeDataModel> GetParkingLotType()
        {
            List<ParkingLotTypeDataModel> parkingLotType = _context.ParkingLotType.ToList();
            return parkingLotType;
        }

        public List<VehicleDataModel> GetVehicle()
        {
            List<VehicleDataModel> vehicles = _context.Vehicle.ToList();
            return vehicles;
        }

        public List<VehicleStatusDataModel> GetVehicleStatus()
        {
            List<VehicleStatusDataModel> vehicleStatusList = _context.VehicleStatus.ToList();
            return vehicleStatusList;

        }
    }
}
