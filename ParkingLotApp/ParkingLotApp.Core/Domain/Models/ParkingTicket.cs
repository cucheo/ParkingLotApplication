using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Domain.Models;

//  Parking ticket Class
public class ParkingTicket
{
    public string TicketNumber { get;  set; }
    public int SpotNumber { get; set; }
    public DateTime EntryDateTime { get; set; }


   // public int Counter { get; private set; }

   // public ParkingTicket()
   // {
   //     Counter = 0;
   // }

   //public string GenerateTicketNumber()
   //{
   //     Counter++;
   //     return Counter.ToString("D3");

   //}
}