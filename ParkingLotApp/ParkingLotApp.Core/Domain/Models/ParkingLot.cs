using ParkingLotApp.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Domain.Models;

// Parking lot class
public class ParkingLot
{
    //Injecting the FeeModel interface
    private readonly IFeeModel feeModel;
    

    public ParkingLot(IFeeModel feeModel)
    {
        this.feeModel = feeModel;
    }

    public ParkingTicket ParkVehicle(ParkedVehicle vehicle)
    {
        // Generate parking ticket
        ParkingTicket ticket = new ParkingTicket
        {
            TicketNumber = GenerateTicketNumber(),
            SpotNumber = vehicle.SpotNumber,
            EntryDateTime = vehicle.EntryDateTime
        };
  
        return ticket;
    }

    public Receipt UnparkVehicle(ParkingTicket ticket)
    {
        // Get the parked vehicle details using the ticket to calculate fees
        //ParkedVehicle vehicle = RetrieveParkedVehicle(ticket.SpotNumber);
        decimal fee = feeModel.CalculateFee(ticket.EntryDateTime, DateTime.Now);

        // Generate receipt
        Receipt receipt = new Receipt
        {
            ReceiptNumber = GenerateReceiptNumber(),
            EntryDateTime = ticket.EntryDateTime,
            ExitDateTime = DateTime.Now,
            Fee= fee
        };    

        return receipt;
    }

    //Generate TIcket Number
    private  string GenerateTicketNumber()
    {
        int  ticketNumber = 0;
        
        ticketNumber++;

        return ticketNumber.ToString("D3"); 
    }

    //method to generate Receipt Number
    private string GenerateReceiptNumber()
    {
        int receiptNumber = 0;
        receiptNumber++;

        return $"R-{receiptNumber.ToString("D3")}";
    }

    //private ParkedVehicle RetrieveParkedVehicle(int spotNumber)
    //{
    //    List<ParkedVehicle> parkedVehicles = new List<ParkedVehicle>();

    //    ParkedVehicle parked = parkedVehicles.FirstOrDefault();

    //    return parked;
    //}
}
