using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptOrders.Models
{
    public class ProductsInOrder 
    {
        public int Id { get; set; }
        
        public int OrderNumber { get; set; }
        public int ProductNumber { get; set; }

        public int Quantity { get; set; }
    }
}
