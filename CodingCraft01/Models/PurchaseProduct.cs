using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class PurchaseProduct
    {
        [Key]
        public Guid PurchaseProductId { get; set; }
        public Guid ProductId { get; set; }

        public Guid PurchaseId { get; set; }
 
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}