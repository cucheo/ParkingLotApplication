using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Core.Domain.Models;

//  Receipt class
public class Receipt
{
    public string  ReceiptNumber { get; set; }=string.Empty;
    public DateTime EntryDateTime { get; set; }
    public DateTime ExitDateTime { get; set; }
    public decimal Fee { get; set; }
}
