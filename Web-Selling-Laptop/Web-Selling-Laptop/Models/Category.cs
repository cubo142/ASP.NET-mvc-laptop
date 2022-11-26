using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Selling_Laptop.Models
{
    public class Category
    {
        [Key]
        public int CateId { get; set;}
        public string CateName { get; set; }
        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}