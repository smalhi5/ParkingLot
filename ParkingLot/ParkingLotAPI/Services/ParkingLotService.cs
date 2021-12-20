using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ParkingLotAPI.Interfaces;
using ParkingLotAPI.Models;
using ParkingLotData.Interfaces;
using ParkingLotData.DataModels;

namespace ParkingLotAPI.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotDataService _parkingLotDataService;

        public ParkingLotService(IParkingLotDataService parkingLotDataService)
        {
            _parkingLotDataService = parkingLotDataService; 
        }

        public string ParkingLotStatus()
        {
            List<ParkingLotDataModel> parkingLots = _parkingLotDataService.GetParkingLots();
            if(parkingLots is null)
            {
                throw new Exception("Something went wrong in getting the data");
            }

            if (parkingLots.Count == 0)
            {
                return "No data available";
            }

            var parkingLotsLeft = parkingLots.Where(x => x.Status == "E").ToList();

            if (parkingLotsLeft.Count == 0)
            {
                return "Parking lot is full";
            }
            else if (parkingLots.Count != parkingLotsLeft.Count)
            {
                return "There are " + parkingLotsLeft.Count + " parking spot left";
            }
            else {
                return "The parking lot is empty";
            }
        }

        public string TotalParking()
        {
            List<ParkingLotDataModel> parkingLots = _parkingLotDataService.GetParkingLots();
            if (parkingLots is null)
            {
                throw new Exception("Something went wrong in getting the data");
            }

            if (parkingLots.Count == 0)
            {
                return "No data available";
            }

            return "There are " + parkingLots.Count + " total parking lots";
        }

        public string SpotsStatus(ParkingLotTypeRequestModel parkingType)
        {
            List<ParkingLotDataModel> parkingLots = _parkingLotDataService.GetParkingLots();
            List<ParkingLotTypeDataModel> parkingLotType = _parkingLotDataService.GetParkingLotType();

            if (parkingLots is null || parkingLotType is null)
            {
                throw new Exception("Something went wrong in getting the data");
            }

            if (parkingLots.Count == 0 || parkingLotType.Count == 0)
            {
                return "No data abailable";
            }

            ParkingLotTypeDataModel parkType = parkingLotType.Where(x => x.Name == parkingType.Name.ToLower()).FirstOrDefault();
            var parkingLotTypeLeft = parkingLots.Where(parkingLot => parkingLot.Status == "E" && parkingLot.TypeId == parkType.Id).ToList();
            var totalParkingLotType = parkingLots.Where(parkingLot => parkingLot.TypeId == parkType.Id).ToList();

            if (parkingLotTypeLeft.Count == 0)
            {
                return "All " + parkingType.Name + " parking spots are taken";
            }
            else if (parkingLotTypeLeft.Count != totalParkingLotType.Count)
            {
                return "There are " + parkingLotTypeLeft.Count + " " + parkingType.Name + " parking spots left";
            }
            else
            {
                return "None of the " + parkingType.Name + " parking spots are being used";
            }
        }

        public string SpotTakenByVehicleType(VehicleTypeRequestModel vehicleType)
        {
            List<VehicleDataModel> vehicleList = _parkingLotDataService.GetVehicle();
            List<VehicleStatusDataModel> vehicleStatusList = _parkingLotDataService.GetVehicleStatus();
            int count = 0;

            if (vehicleList is null || vehicleStatusList is null)
            {
                throw new Exception("Something went wrong in getting the data");
            }

            if (vehicleList.Count == 0 || vehicleStatusList.Count == 0)
            {
                return "No data abailable";
            }

            var vehicleListByType = vehicleList.Where(vehicle => vehicle.Type == vehicleType.VehicleType.ToLower()).ToList();

            foreach (var vbt in vehicleListByType)
            {
                var vs = vehicleStatusList.Where(vehicleStatus => vehicleStatus.VecicleId == vbt.Id && vehicleStatus.Status == "CI").ToList();
                count += vs.Count;
            }

            return vehicleType.VehicleType + "s are taking " + count + " parking lots";
        }

        public VehicleModel GetVehicleByParkId(ParkingLotIdRequestModel parkingId)
        {
            List<VehicleDataModel> vehicleList = _parkingLotDataService.GetVehicle();
            List<VehicleStatusDataModel> vehicleStatusList = _parkingLotDataService.GetVehicleStatus();
            VehicleModel vehicle = new VehicleModel();

            if (vehicleList is null || vehicleStatusList is null)
            {
                throw new Exception("Something went wrong in getting the data");
            }

            if (vehicleList.Count == 0 || vehicleStatusList.Count == 0)
            {
                return vehicle;
            }

            var vehicleStatus = vehicleStatusList.Where(x => x.ParkId == parkingId.Id).FirstOrDefault();
            var veh = vehicleList.Where(v => v.Id == vehicleStatus.VecicleId).FirstOrDefault();
            vehicle.Map(veh);
            return vehicle;
        }
        public VehicleModel GetVehicleByParkName(ParkingLotNameRequestModel parkingName)
        {
            List<VehicleDataModel> vehicleList = _parkingLotDataService.GetVehicle();
            List<VehicleStatusDataModel> vehicleStatusList = _parkingLotDataService.GetVehicleStatus();
            List<ParkingLotDataModel> parkingLotList = _parkingLotDataService.GetParkingLots();
            VehicleModel vehicle = new VehicleModel();

            if (vehicleList is null || vehicleStatusList is null || parkingLotList is null)
            {
                throw new Exception("Something went wrong in getting the data");
            }

            if (vehicleList.Count == 0 || vehicleStatusList.Count == 0 || parkingLotList.Count == 0)
            {
                return vehicle;
            }

            var parkingLot = parkingLotList.Where(p => p.Name.ToLower() == parkingName.Namme.ToLower()).FirstOrDefault();
            var vehicleStatus = vehicleStatusList.Where(x => x.ParkId == parkingLot.Id).FirstOrDefault();
            var veh = vehicleList.Where(v => v.Id == vehicleStatus.VecicleId).FirstOrDefault();
            vehicle.Map(veh);
            return vehicle;
        }
    }
}
