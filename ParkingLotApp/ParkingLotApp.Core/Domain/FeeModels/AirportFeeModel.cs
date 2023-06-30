using ParkingLotApp.Core.Abstraction;
using ParkingLotApp.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Domain.FeeModels;


//  Airport location implementation of the fee model
public class AirportFeeModel : IFeeModel
{
    //Calculate Fee
    public decimal CalculateFee(DateTime entryTime, DateTime exitTime)
    {
        TimeSpan duration = exitTime - entryTime;
        int days = duration.Days;
        int hours = duration.Hours;

        if (days < 1)
        {
            if (hours < 1)
                return 0;
            else if (hours < 8)
                return GetFeeForVehicleType(VehicleType.Motorcycle, hours);
            else if (hours < 24)
                return GetFeeForVehicleType(VehicleType.Motorcycle, 8) +
                       GetFeeForVehicleType(VehicleType.CarSUV, hours - 8);
            else
                return GetFeeForVehicleType(VehicleType.Motorcycle, 8) +
                       GetFeeForVehicleType(VehicleType.CarSUV, 16) +
                       GetFeeForVehicleType(VehicleType.CarSUV, hours - 24);
        }
        else
        {
            return GetFeeForVehicleType(VehicleType.CarSUV, 24) * days;

        }
    }

    private decimal GetFeeForVehicleType(VehicleType vehicleType, int hours)
    {
        switch (vehicleType)
        {
            case VehicleType.Motorcycle:
                if (hours < 1)
                    return 0;
                else if (hours < 8)
                    return 40;
                else if (hours < 24)
                    return 60;
                else
                    return 80;
            case VehicleType.CarSUV:
                if (hours < 12)
                    return 60;
                else if (hours < 24)
                    return 80;
                else
                    return 100;
            default:
                throw new ArgumentOutOfRangeException(nameof(vehicleType), "Invalid vehicle type.");
        }
    }
}
