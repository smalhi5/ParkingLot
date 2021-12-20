using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotData.DataModels;

namespace ParkingLotData.Services
{
    public class ParkingLotContext : DbContext
    {
        public ParkingLotContext(DbContextOptions<ParkingLotContext> options) : base(options)
        {

        }

        public DbSet<ParkingLotDataModel> ParkingLot { get; set; }
        public DbSet<ParkingLotTypeDataModel> ParkingLotType { get; set; }
        public DbSet<VehicleDataModel> Vehicle { get; set; }
        public DbSet<VehicleStatusDataModel> VehicleStatus { get; set; }
    }
}
