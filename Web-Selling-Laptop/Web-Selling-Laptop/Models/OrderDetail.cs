using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Selling_Laptop.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int LaptopId { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public virtual OrderPro OrderPro { get; set; }
        public virtual Laptop Laptop { get; set; }
    }
}