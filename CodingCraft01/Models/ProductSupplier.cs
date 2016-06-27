using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class ProductSupplier
    {
        [Key]
        public Guid ProductSupplierId { get; set; }
        [Required]
        public decimal Price { get; set; }
 
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}