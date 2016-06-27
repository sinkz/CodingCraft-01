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
        public int ProductSupplierId { get; set; }
        [Required]
        public decimal Price { get; set; }
 
        public int ProductId { get; set; }
        public int SupplierId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}