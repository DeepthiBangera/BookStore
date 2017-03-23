using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.OrderDetails
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int Quantity { get; set; }
        public float TotalAmount { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
    }
}
