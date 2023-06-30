using ParkingLotApp.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Domain.Models;

// Parked vehicle class
public class ParkedVehicle
{
    public int SpotNumber { get; set; }
    public VehicleType VehicleType { get; set; }
    public DateTime EntryDateTime { get; set; }
}


















