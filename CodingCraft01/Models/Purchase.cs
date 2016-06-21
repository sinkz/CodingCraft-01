using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft01.Models
{
    public class Purchase
    {
        [Key]
        public int IDPurchase { get; set; }
        public decimal Total { get; set; }
        public DateTime DatePurchase { get; set; }
        public DateTime DatePayment { get; set; }

        public List<ProductsSuppliers> ProductItems { get; set; }

        public ApplicationUser User { get; set; }
    }
}