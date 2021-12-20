using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotAPI.Models
{
    public class ParkingLotTypeRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
