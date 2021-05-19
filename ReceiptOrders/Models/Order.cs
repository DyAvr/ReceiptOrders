using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptOrders.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string SupplyContract { get; set; }
        public string Provider { get; set; }
        public string StorageLocation { get; set; }
    }
}
