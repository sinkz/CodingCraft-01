﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<ProductSupplier> ProductsSuppliers { get; set; }
        public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    }
}