using ParkingLotApp.Core.Abstraction;
using ParkingLotApp.Core.Domain.Models;


namespace ParkingLotApp.Core.Domain.FeeModels;

// Mall location implementation of the fee model
public class MallFeeModel : IFeeModel
{
    //Calculate Fee
    public decimal CalculateFee(DateTime entryDateTime, DateTime exitDateTime)
    {
        TimeSpan duration = exitDateTime - entryDateTime;
        int hours = (int)Math.Ceiling(duration.TotalHours);

        decimal fee =  GetFeeForVehicleType(VehicleType.Motorcycle,hours);
        
        return fee;
       
    }

    private decimal GetFeeForVehicleType(VehicleType vehicleType,int hours)
    {

        switch (vehicleType)
        {
            case VehicleType.Motorcycle:
                return 10 * hours;
            case VehicleType.CarSUV:
                return 20 * hours;
            case VehicleType.BusTruck:
                return 50 * hours;
            default:
                throw new ArgumentOutOfRangeException(nameof(vehicleType), "Invalid vehicle type.");
        }
    }

   
}
