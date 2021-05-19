using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptOrders.Models.ViewModels
{
    public class OutputViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductsInOrder> ProductsInOrders { get; set; }
    }
}
