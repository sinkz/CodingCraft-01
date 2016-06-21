using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class ProductsSuppliers
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Product")]
        public int IdProduct { get; set; }
        [DisplayName("Supplier")]
        public int IDSupplier { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}