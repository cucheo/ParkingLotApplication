using ParkingLotApp.Core.Abstraction;
using ParkingLotApp.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Domain.FeeModels;

// Stadium location implementation of the fee model
public class StadiumFeeModel : IFeeModel
{
    //Calculate Fee
    public decimal CalculateFee(DateTime entryTime, DateTime exitTime)
    {
        TimeSpan duration = exitTime - entryTime;
        int hours = (int)Math.Ceiling(duration.TotalHours);

        if (hours <= 0)
            return 0;
        else if (hours <= 4)
            return GetFeeForVehicleType(VehicleType.Motorcycle, hours);
        else if (hours <= 12)
            return GetFeeForVehicleType(VehicleType.Motorcycle, 4) +
                   GetFeeForVehicleType(VehicleType.CarSUV, hours - 4);
        else
            return GetFeeForVehicleType(VehicleType.Motorcycle, 4) +
                   GetFeeForVehicleType(VehicleType.CarSUV, 8) +
                   GetFeeForVehicleType(VehicleType.CarSUV, hours - 12);
    }

    private decimal GetFeeForVehicleType(VehicleType vehicleType, int hours)
    {
        switch (vehicleType)
        {
            case VehicleType.Motorcycle:
                if (hours < 4)
                    return 30;
                else if (hours < 12)
                    return 60;
                else
                    return 100 * (hours - 12);
            case VehicleType.CarSUV:
                if (hours < 4)
                    return 60;
                else
                    return 120;
            default:
                throw new ArgumentOutOfRangeException(nameof(vehicleType), "Invalid vehicle type.");
        }
    }
}

