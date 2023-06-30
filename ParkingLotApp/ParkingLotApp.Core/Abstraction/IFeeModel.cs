using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Abstraction;

//Interface defining the common behavior for all fee models -using the Strategy Pattern
public interface IFeeModel
{
    decimal CalculateFee(DateTime entryTime, DateTime exitTime);

}
