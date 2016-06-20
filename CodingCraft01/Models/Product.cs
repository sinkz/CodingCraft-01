using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Enter Product Name")]
        [StringLength(100, ErrorMessage = "The max lenght is{1}", MinimumLength = 6)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual List<Supplier>ProductsSuppliers { get; set; }
    }
}