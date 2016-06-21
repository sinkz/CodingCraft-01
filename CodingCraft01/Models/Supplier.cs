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
        public int IDSupplier { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductsSuppliers> ProductsSuppliers { get; set; }
    }
}