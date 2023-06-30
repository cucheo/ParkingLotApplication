using Xunit;
using ParkingLotApp.Core.Abstraction;
using ParkingLotApp.Core.Domain.FeeModels;
using ParkingLotApp.Core.Domain.Models;


namespace ParkingLot.Tests
{
    public class MallFeeModelShould
    {
        [Fact]
        public void Return_40_For_Motorcycle_For_3_Hours_And_Additional_Minutes()
        {
            //arrange
            ParkingLotApp.Core.Domain.Models.ParkingLot sut = new ParkingLotApp.Core.Domain.Models.ParkingLot(new MallFeeModel());
            ParkedVehicle vehicle = new ParkedVehicle
            {
                SpotNumber = 1,
                VehicleType = VehicleType.Motorcycle,
                EntryDateTime = DateTime.Now.AddHours(-3) // 
            };

            //act
            ParkingTicket ticket = sut.ParkVehicle(vehicle);
            Receipt receipt = sut.UnparkVehicle(ticket);
         
            //assert 
            Assert.Equal(receipt.Fee, 40);
        }

    }
}