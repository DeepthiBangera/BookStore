using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.OrderMaster
{
    public class OrderMaster
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public string Address { get; set; }
        public float FinalAmount { get; set; }
    }
}
