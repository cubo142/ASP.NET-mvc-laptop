using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Selling_Laptop.Models
{
    public class Laptop
    {
        [Key]
        public int LaptopId { get; set; }

        [Required]
        public string LaptopName { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Card { get; set; }
        public string HDH { get; set; }
        public string USB { get; set; }
        public double Price { get; set; }
        public string ImgPath { get; set; }
        public int CateId { get; set; }
        public virtual Category Category { get; set; }

     
    }
}