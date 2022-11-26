using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Selling_Laptop.Models
{
    public class OrderPro
    {
        [Key]
        public int OrderID { get; set; }
        public int? UserID { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public string SDTPro { get; set; }
        public string CusPro { get; set; }
        public virtual User User { get; set; }
    }
}