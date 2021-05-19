using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptOrders.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int Cost { get; set; }
    }
}
