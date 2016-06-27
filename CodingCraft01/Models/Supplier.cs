using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<ProductSupplier> ProductsSuppliers { get; set; }
    }
}